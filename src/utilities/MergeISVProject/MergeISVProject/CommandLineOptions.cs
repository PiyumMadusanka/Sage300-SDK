﻿// The MIT License (MIT) 
// Copyright (c) 1994-2018 The Sage Group plc or its licensors.  All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of 
// this software and associated documentation files (the "Software"), to deal in 
// the Software without restriction, including without limitation the rights to use, 
// copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the 
// Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#region Imports
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MergeISVProject.CustomAttributes;
using MergeISVProject.Interfaces;
#endregion

namespace MergeISVProject
{
	public class CommandLineOptions : ICommandLineOptions
    {
		#region Constants
		// This is the default prefix character block when specifying
		// command-line arguments to this program.
        private const string DEFAULT_PREFIX = "--";

		private const string SINGLE_SPACE = @" ";
		private const char SINGLE_SPACE_CHAR = ' ';
		#endregion

		#region Private Variables
		private string divider = new String('-', 105);
        private string UsageInstructionsTemplate =
                @" Program Name:          {0}" + Environment.NewLine +
                 " Version:               {1}" + Environment.NewLine +
				 " " + Environment.NewLine +
				 " Copyright:             (c) 1994-2018 The Sage Group plc or its licensors.  " + Environment.NewLine +
				 "                        All rights reserved." + Environment.NewLine +
				 " License:               The MIT Licence (MIT)" + Environment.NewLine +
				 " " + Environment.NewLine +
                 " Required Parameters:" + Environment.NewLine +
                 " " + Environment.NewLine +
                 " {2}" + Environment.NewLine +
                 "" + Environment.NewLine +
                 " Optional Parameter(s):" + Environment.NewLine +
                 " " + Environment.NewLine +
                 " {3}" + Environment.NewLine;


        private string[] rawArgList { get; set; }
		private string[] cleanArgList { get; set; }
        #endregion

        #region Public Properties

		public string[] Arguments { get { return cleanArgList; } }
        public string OptionPrefix { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationVersion { get; set; }
        public List<string> LoadErrors { get; set; }
        public string UsageMessage { get; set; }
        public string ModuleId
        {
            get { return MenuFilename.OptionValue.Substring(0, 2); }
        }
        #endregion

        #region Public Properties that map to valid command-line options

        // Note to developers: 
        //
        // If you wish to add new command-line options,
        // please add them to this section
		// Presently the code can only deal with strings and booleans

        // Required Command-Line Arguments
        [RequiredArgument]
        [IsExistingFolder]
        public CommandLineOption<string> SolutionPath { get; set; }

        [RequiredArgument]
        [IsExistingFolder]
        public CommandLineOption<string> WebProjectPath { get; set; }

        [RequiredArgument]
        public CommandLineOption<string> MenuFilename { get; set; }

        [RequiredArgument]
        public CommandLineOption<string> BuildProfile { get; set; }

        [RequiredArgument]
        [IsExistingFolder]
        public CommandLineOption<string> DotNetFrameworkPath { get; set; }

        // Optional Command-Line Arguments
        [OptionalArgument]
        public CommandLineOption<bool> Minify { get; set; }

        [OptionalArgument]
        public CommandLineOption<bool> NoDeploy { get; set; }

        [OptionalArgument]
        public CommandLineOption<bool> TestDeploy { get; set; }

        [OptionalArgument]
        public CommandLineOption<bool> Log { get; set; }

		#endregion

		#region Constructor(s)
		/// <summary>
		/// Empty constructor for unit testing purposes only
		/// </summary>
		public CommandLineOptions()
		{
			// Empty constructor for unit testing purposes
		}

		/// <summary>
		/// The primary constructor
		/// </summary>
		/// <param name="appName"></param>
		/// <param name="appVersion"></param>
		/// <param name="prefix"></param>
		/// <param name="args"></param>
		public CommandLineOptions(string appName, string appVersion, string[] args, string prefix=DEFAULT_PREFIX)
        {
            OptionPrefix = prefix;
            ApplicationName = appName;
            ApplicationVersion = appVersion;

			// If the argument array has only a single entry, then the
			// arguments list will likely have /r/n characters in it
			// so we need to replace these with spaces and create a 
			// new arguments array
			rawArgList = args;
			cleanArgList = CleanupArguments(args);

            LoadErrors = new List<string>();

            // Initialize the CommandLineOptions
            #region Create CommandLineOptions

            SolutionPath = new CommandLineOption<string>() 
            { 
                Name = "solutionpath",
                AliasList = new List<string>() { "s", "sol", "sp", "solution" },
                Description = "MS Visual Studio Solution path", 
                Required = true, 
                OptionValue = "",
                ExampleValue = @"<path>"
            };
            LoadString(SolutionPath, cleanArgList);

            WebProjectPath = new CommandLineOption<string>() 
            { 
                Name = "webprojectpath", 
                AliasList = new List<string>() {"p", "wpp", "projectpath"},
                Description = "MS Visual Studio Web Project path", 
                Required = true, 
                OptionValue = "",
                ExampleValue = @"<path>"
            };
            LoadString(WebProjectPath, cleanArgList);

            MenuFilename = new CommandLineOption<string>() 
            { 
                Name = "menufilename",
                AliasList = new List<string>() { "m", "menu", "menufile" },
                Description = "Sage 300 Menu definition file name (i.e. XXMenuDetails.xml)", 
                Required = true, 
                OptionValue = "",
                ExampleValue = @"<name>"
            };
            LoadString(MenuFilename, cleanArgList);

            BuildProfile = new CommandLineOption<string>() 
            { 
                Name = "buildprofile",
                AliasList = new List<string>() { "b", "bp" },
                Description = "Visual Studio project build configuration (only release supported)", 
                Required = true, 
                OptionValue = "Release",
                ExampleValue = @"<name>"
            };
            LoadString(BuildProfile, cleanArgList);

            DotNetFrameworkPath = new CommandLineOption<string>() 
            { 
                Name = "dotnetframeworkpath",
                AliasList = new List<string>() { "f", "dotnet", "dotnetframework", "netframework", "framework" },
                Description = ".NET Framework path containing aspnet_compile.exe", 
                Required = true, 
                OptionValue = "",
                ExampleValue = @"<path>"
            };
            LoadString(DotNetFrameworkPath, cleanArgList);

            Minify = new CommandLineOption<bool>() 
            { 
                Name = "minify",
                AliasList = new List<string>() { "min" },
                Description = "Minify javascript files", 
                Required = false, 
                OptionValue = false,
                ExampleValue = @""
            };
            LoadBoolean(Minify, cleanArgList);

            NoDeploy = new CommandLineOption<bool>() 
            { 
                Name = "nodeploy",
                AliasList = new List<string>() { "nd" },
                Description = "Do NOT copy assets to Sage 300 installation directory", 
                Required = false, 
                OptionValue = false,
                ExampleValue = @""
            };
            LoadBoolean(NoDeploy, cleanArgList);

            TestDeploy = new CommandLineOption<bool>()
            {
                Name = "testdeploy",
                AliasList = new List<string>() { "nd" },
                Description = "Simulate copying of assets to the Sage 300 installation directory",
                Required = false,
                OptionValue = false,
                ExampleValue = @""
            };
            LoadBoolean(TestDeploy, cleanArgList);

            Log = new CommandLineOption<bool>()
            {
                Name = "log",
                AliasList = new List<string>() { "logging" },
                Description = "Generate a log file in the current working folder",
                Required = false,
                OptionValue = false,
                ExampleValue = @""
            };
            LoadBoolean(Log, cleanArgList);

            #endregion

            this.UsageMessage = BuildUsageMessage();
        }
		#endregion

		#region Private Methods

		/// <summary>
		/// Ensure that the command-line arguments array is well-formed
		/// If the parameters passed into the program contain
		/// NewLine (\n\r) characters, we need to get rid of them
		/// and rebuild the arguments array before we can use it.
		/// </summary>
		/// <param name="argsIn">The original arguments array</param>
		/// <returns>A well-formed arguments array</returns>
		private string[] CleanupArguments(string[] argsIn)
		{
			var tempArgList = new List<string>();
			var argList = new List<string>();

			// First, replace all NewLine characters, if they exist
			// in any of the array entries.
			// The array may be 1 or more in size
			foreach (var s in argsIn)
			{
				var temp = s.Replace(Environment.NewLine, SINGLE_SPACE);
				tempArgList.Add(temp);
			}

			// Next, go through each entry, split up on spaces
			// and add each piece to the final argument list
			foreach (var s in tempArgList)
			{
				foreach (var a in s.Split(SINGLE_SPACE_CHAR).ToList<string>())
				{
					var temp = a;
					if (temp.Length > 0)
					{
						temp = temp.Replace("\"", "");
						argList.Add(temp);
					}
				}
			}

			// Finally, convert to a simple array and return!
			return argList.ToArray();
		}

		/// <summary>
		/// Look through all of the command-line arguments to
		/// determine if there is an entry applicable to
		/// assignment to the option variable passed into the function.
		/// This method handles string based command-line arguments
		/// There is a corresponding method called LoadBoolean to handle 
		/// boolean flag type arguments.
		/// </summary>
		/// <param name="option"></param>
		/// <param name="args"></param>
		private void LoadString(CommandLineOption<string> option, string[] args)
		{
			var theArg = string.Empty;

			if (Array.Exists(args, s =>
			{
				theArg = s;

				// Split the prefix+flag and the actual value
				var optionName = GetArgumentNameOnly(theArg.Replace(Environment.NewLine, String.Empty));

				// Check the regular name
				if (optionName == option.Name)
					return true;

				// Check any Alias'
				if (option.AliasList.Contains(optionName))
					return true;

				return false;
			}))
			{
				var valueFromArg = theArg.Split('=')[1];
				if (option.Required)
				{
					option.LoadError = valueFromArg.Length == 0 ? true : false;
				}
				else
				{
					option.LoadError = false;
				}

				if (option.LoadError)
				{
					LoadErrors.Add($"{new String(' ', 10)}Error parsing '{OptionPrefix + option.Name}'. No value was set.");
				}


				// Now, if this property is marked with the [IsExistingFolder] attribute,
				// ensure that the value is an actual existing folder.
				if (IsPropertyMarkedAsExistingFolder(option))
				{
					// Only do this if the value of the argument 
					// has a length > 0. 
					// No sense in checking for a directory of zero length.
					// Zero length arguments were handled in the previous
					// code block :)
					if (valueFromArg.Length > 0)
					{
						var folder = valueFromArg.Trim();
						if (!Directory.Exists(folder))
						{
							// Error: folder doesn't exist
							option.LoadError = true;
							LoadErrors.Add($"{new String(' ', 10)}Error parsing '{OptionPrefix + option.Name}'. The folder '{folder}' does not exist.");
						}
					}
				}

				option.OptionValue = valueFromArg;
			}
		}

		/// <summary>
		/// Look through all of the command-line arguments to
		/// determine if there is an entry applicable to
		/// assignment to the option variable passed into the function.
		/// This method handles boolean based command-line arguments
		/// There is a corresponding method called LoadString to handle 
		/// string type arguments.
		/// </summary>
		/// <param name="option"></param>
		/// <param name="args"></param>
		private void LoadBoolean(CommandLineOption<bool> option, string[] args)
		{
			var theArg = string.Empty;
			if (Array.Exists(args, s =>
			{
				theArg = s;

				// Split the prefix+flag and the actual value
				var optionName = GetArgumentNameOnly(theArg.Replace(Environment.NewLine, String.Empty));

				// Check the regular name
				if (optionName == option.Name)
					return true;

				// Check any Alias'
				if (option.AliasList.Contains(optionName))
					return true;

				return false;
			}))
			{
				// Since this is a boolean flag we only care that it's defined
				// It doesn't need to have any kind of value
				option.OptionValue = true;
				option.LoadError = false;
			}
			else
			{
				option.LoadError = option.Required;
			}
		}

		/// <summary>
		/// Gets the name of the command-line argument 
		/// without any prefix characters or assigned values
		/// Example: 
		///     Input:   --argumentname=blahblah
		///     Output:  argumentname
		/// </summary>
		/// <param name="arg">The individual argument</param>
		/// <returns>The argument name only</returns>
		private string GetArgumentNameOnly(string arg)
		{
			var temp = arg.Split('=')[0];
			if (OptionPrefix.Length > 0)
			{
				temp = temp.Substring(OptionPrefix.Length, temp.Length - OptionPrefix.Length);
			}
			return temp;
		}

		/// <summary>
		/// Build a text block describing how to run this program!
		/// </summary>
		/// <returns>A string representation of the usage instructions</returns>
		private string BuildUsageMessage()
		{
			var requiredParams = GetRequiredPropertiesAsString();
			var optionalParams = GetOptionalPropertiesAsString();
			var msg = divider + Environment.NewLine;
			msg += string.Format(UsageInstructionsTemplate, ApplicationName,
															   ApplicationVersion,
															   requiredParams,
															   optionalParams);
			msg += divider;
			return msg;
		}

		/// <summary>
		/// Interate through this class to find all properties marked with the
		/// RequiredArgument attribute. Once the list of properties is found,
		/// go through each and extract some values to build the line of text
		/// </summary>
		/// <returns>The required arguments as a string</returns>
		private string GetRequiredPropertiesAsString()
		{
			return GetPropertiesByAttributeAsString(new RequiredArgumentAttribute());
		}

		/// <summary>
		/// Interate through this class to find all properties marked with the
		/// OptionalArgument attribute. Once the list of properties is found,
		/// go through each and extract some values to build the line of text
		/// </summary>
		/// <returns>The optional arguments as a string</returns>
		private string GetOptionalPropertiesAsString()
		{
			return GetPropertiesByAttributeAsString(new OptionalArgumentAttribute());
		}

		/// <summary>
		/// Generic method to build a string of properties marked
		/// with a particular attribute.
		/// </summary>
		/// <param name="att"></param>
		/// <returns>A formatted string of text</returns>
		private string GetPropertiesByAttributeAsString(Attribute att)
		{
			var sb = new StringBuilder();
			var requiredProperties = this.
									 GetType().
									 GetProperties().
									 Where(x => x.GetCustomAttributes(att.GetType(), true).Any());

			foreach (var propertyInfo in requiredProperties)
			{
				dynamic valueSet = propertyInfo.GetValue(this, null);
				var name = valueSet.Name;
				var exampleValue = valueSet.ExampleValue;
				var description = valueSet.Description;
				sb.AppendLine(MakeFormattedLine(OptionPrefix, name, exampleValue, description));
			}
			return sb.ToString();
		}

		/// <summary>
		/// How many required properties are defined in this class?
		/// Use the [RequiredArgument] attribute to determine this.
		/// </summary>
		/// <returns>The count of the required properties</returns>
		private int GetRequiredPropertiesCount()
		{
			Attribute att = new RequiredArgumentAttribute();
			var count = this.
						GetType().
						GetProperties().
						Where(x => x.GetCustomAttributes(att.GetType(), true).Any()).Count();
			return count;
		}

		/// <summary>
		/// Check to see if a property has been tagged with the 
		/// [IsExistingFolder] attribute
		/// </summary>
		/// <returns>true : Property is marked with attribute, false : not marked with attribute</returns>
		private bool IsPropertyMarkedAsExistingFolder(CommandLineOption<string> option)
		{
			Attribute att = new IsExistingFolderAttribute();
			var propertiesMarkedAsFolders = this.
											GetType().
											GetProperties().
											Where(x => x.GetCustomAttributes(att.GetType(), true).Any());

			foreach (var propertyInfo in propertiesMarkedAsFolders)
			{
				dynamic valueSet = propertyInfo.GetValue(this, null);
				if (valueSet != null)
				{
					if (option.Name == valueSet.Name)
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// Build a string containing the command-line argument name, an example value and description.
		/// This method is used with displaying the help text block.
		/// </summary>
		/// <param name="prefix"></param>
		/// <param name="name"></param>
		/// <param name="exampleValue"></param>
		/// <param name="description"></param>
		/// <returns>A formatted string</returns>
		private string MakeFormattedLine(string prefix, string name, string exampleValue, string description)
		{
			const string lineTemplate = "{0}{1,-30}{2}";
			var text = prefix + name;
			text += exampleValue.Length > 0 ? "=" + exampleValue : string.Empty;
			return String.Format(lineTemplate, new String(' ', 5), text, description);
		}

		#endregion

		#region Public Methods
		/// <summary>
		/// Were there any errors during startup (Loading of arguments)
		/// </summary>
		/// <returns>true : Errors occurred | False : No errors</returns>
		public bool AnyErrors()
        {
			// How many defined required properties are there?
			var requiredFieldCount = GetRequiredPropertiesCount();

            return cleanArgList.Length < requiredFieldCount ||
                   SolutionPath.LoadError ||
                   WebProjectPath.LoadError ||
                   MenuFilename.LoadError ||
                   BuildProfile.LoadError ||
                   DotNetFrameworkPath.LoadError ||
                   Minify.LoadError ||
                   NoDeploy.LoadError;
        }

        /// <summary>
        /// Build a displayable representation of any and all load error
        /// that occurred.
        /// </summary>
        /// <returns>A string representation of all the errors encountered</returns>
        public string GetLoadErrorsAsText()
        {
            var text = string.Empty;
            foreach (var s in LoadErrors)
            {
                text += s + Environment.NewLine;
            }
            return text;
        }

		#endregion
	}
}