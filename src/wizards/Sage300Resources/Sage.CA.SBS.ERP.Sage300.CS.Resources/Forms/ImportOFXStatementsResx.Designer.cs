﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sage.CA.SBS.ERP.Sage300.CS.Resources.Forms {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ImportOFXStatementsResx {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ImportOFXStatementsResx() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Sage.CA.SBS.ERP.Sage300.CS.Resources.Forms.ImportOFXStatementsResx", typeof(ImportOFXStatementsResx).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OFX Statements (*.aso;*.ofx;*.dbo;*.afx;*.qfx)|*.aso;*.ofx|Text Files (*.txt)|*.txt|All Files (*.*)|*.*.
        /// </summary>
        public static string CdlgFilter {
            get {
                return ResourceManager.GetString("CdlgFilter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The fiscal calendar is empty..
        /// </summary>
        public static string EmptyFiscCal {
            get {
                return ResourceManager.GetString("EmptyFiscCal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Import OFX Statements.
        /// </summary>
        public static string Entity {
            get {
                return ResourceManager.GetString("Entity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A problem occurred and at least one {0} currency statement for account {1} (with transit number {2}) on {3} failed to be reconciled to bank {4}..
        /// </summary>
        public static string ErrintBKStmt {
            get {
                return ResourceManager.GetString("ErrintBKStmt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A problem occurred and at least one {0} currency statement for account {1} on {2} failed to be reconciled to bank {3}..
        /// </summary>
        public static string ErrintCCStmt {
            get {
                return ResourceManager.GetString("ErrintCCStmt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to From Bank Code.
        /// </summary>
        public static string FromBankCode {
            get {
                return ResourceManager.GetString("FromBankCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} statement(s) and {1} new transaction(s) imported, saved, and ready for matching..
        /// </summary>
        public static string ImportedTrx {
            get {
                return ResourceManager.GetString("ImportedTrx", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reconciliations for bank {0} were skipped. To reconcile this bank, you must specify a reconciliation year/period that is {1}-{2} or later..
        /// </summary>
        public static string InvRecYP {
            get {
                return ResourceManager.GetString("InvRecYP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Statement(s) in currency {0} for account {1} (transit number {2}) on {3} were imported successfully for bank {4}..
        /// </summary>
        public static string MatchBKCurrMatchingStmtInfo {
            get {
                return ResourceManager.GetString("MatchBKCurrMatchingStmtInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Warning: Statement(s) in currency {0} for account {1} (transit number {2}) on {3} were imported but are not in the currency range of bank {4}. Review and verify the imported transactions..
        /// </summary>
        public static string MatchBKCurrNotMatchingStmtInfo {
            get {
                return ResourceManager.GetString("MatchBKCurrNotMatchingStmtInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} currency statement(s) for account {1} (with transit number {2}) on {3} matched bank {4}..
        /// </summary>
        public static string MatchBKStmtInfo {
            get {
                return ResourceManager.GetString("MatchBKStmtInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Statement(s) in currency {0} for account {1} on {2} were imported successfully for bank {3}..
        /// </summary>
        public static string MatchCCCurrMatchingStmtInfo {
            get {
                return ResourceManager.GetString("MatchCCCurrMatchingStmtInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Warning: Statement(s) in currency {0} for account {1} on {2} were imported but are not in the currency range of bank {3}. Review and verify the imported transactions..
        /// </summary>
        public static string MatchCCCurrNotMatchingStmtInfo {
            get {
                return ResourceManager.GetString("MatchCCCurrNotMatchingStmtInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} currency statement(s) for account {1} on {2} matched bank {3}..
        /// </summary>
        public static string MatchCCStmtInfo {
            get {
                return ResourceManager.GetString("MatchCCStmtInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} transaction(s) matched, based only on the amount. Please verify the reconciliation..
        /// </summary>
        public static string MatchTrxAmt {
            get {
                return ResourceManager.GetString("MatchTrxAmt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A problem occurred while trying to detect the first active and unlocked fiscal period for the company..
        /// </summary>
        public static string NoActUnlckYP {
            get {
                return ResourceManager.GetString("NoActUnlckYP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Downloaded Bank Statement File.
        /// </summary>
        public static string OFXFile {
            get {
                return ResourceManager.GetString("OFXFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No {0} rate from {1} to {2} on {3}..
        /// </summary>
        public static string OFXNoRateComment {
            get {
                return ResourceManager.GetString("OFXNoRateComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a valid OFX file..
        /// </summary>
        public static string PContents {
            get {
                return ResourceManager.GetString("PContents", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The selected file was created using an unsupported version of OFX..
        /// </summary>
        public static string PVersion {
            get {
                return ResourceManager.GetString("PVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} currency statement(s) is not in the currency range of bank {1} . Continue importing anyway?.
        /// </summary>
        public static string StmtCurrency {
            get {
                return ResourceManager.GetString("StmtCurrency", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} statement(s) processed, {1} reconciled..
        /// </summary>
        public static string StmtProcessInfo {
            get {
                return ResourceManager.GetString("StmtProcessInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To Bank Code.
        /// </summary>
        public static string ToBankCode {
            get {
                return ResourceManager.GetString("ToBankCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} transactions processed in reconciled statements, {1} cleared. (Processed transactions that were not cleared are added as entries the first time they are processed.).
        /// </summary>
        public static string TrxProcessInfo {
            get {
                return ResourceManager.GetString("TrxProcessInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} currency statement(s) for account {1} (with transit number {2}) on {3} did not match any bank records in the specified range..
        /// </summary>
        public static string UnmatchBKStmtInfo {
            get {
                return ResourceManager.GetString("UnmatchBKStmtInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} currency statement(s) for account {1} on {2} did not match any bank records in the specified range..
        /// </summary>
        public static string UnmatchCCStmtInfo {
            get {
                return ResourceManager.GetString("UnmatchCCStmtInfo", resourceCulture);
            }
        }
    }
}
