﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicTacToe {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("TicTacToe.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string WelcomeMessage {
            get {
                return ResourceManager.GetString("WelcomeMessage", resourceCulture);
            }
        }
        
        internal static string BoardIntro {
            get {
                return ResourceManager.GetString("BoardIntro", resourceCulture);
            }
        }
        
        internal static string BoardCoordinate {
            get {
                return ResourceManager.GetString("BoardCoordinate", resourceCulture);
            }
        }
        
        internal static string TakeTurn {
            get {
                return ResourceManager.GetString("TakeTurn", resourceCulture);
            }
        }
        
        internal static string MoveAccepted {
            get {
                return ResourceManager.GetString("MoveAccepted", resourceCulture);
            }
        }
        
        internal static string IncorrectFormat {
            get {
                return ResourceManager.GetString("IncorrectFormat", resourceCulture);
            }
        }
        
        internal static string CellUnavailable {
            get {
                return ResourceManager.GetString("CellUnavailable", resourceCulture);
            }
        }
        
        internal static string OutsideOfBounds {
            get {
                return ResourceManager.GetString("OutsideOfBounds", resourceCulture);
            }
        }
        
        internal static string Draw {
            get {
                return ResourceManager.GetString("Draw", resourceCulture);
            }
        }
        
        internal static string YouHaveWon {
            get {
                return ResourceManager.GetString("YouHaveWon", resourceCulture);
            }
        }
        
        internal static string ComputerOrPersonPlayerSelection {
            get {
                return ResourceManager.GetString("ComputerOrPersonPlayerSelection", resourceCulture);
            }
        }
        
        internal static string IncorrectPlayerSelection {
            get {
                return ResourceManager.GetString("IncorrectPlayerSelection", resourceCulture);
            }
        }
        
        internal static string BoardSizeRequest {
            get {
                return ResourceManager.GetString("BoardSizeRequest", resourceCulture);
            }
        }
        
        internal static string PleaseEnterOneNumberOnly {
            get {
                return ResourceManager.GetString("PleaseEnterOneNumberOnly", resourceCulture);
            }
        }
        
        internal static string AskNumberOfComputerPlayers {
            get {
                return ResourceManager.GetString("AskNumberOfComputerPlayers", resourceCulture);
            }
        }
        
        internal static string AskNumberOfPlayers {
            get {
                return ResourceManager.GetString("AskNumberOfPlayers", resourceCulture);
            }
        }
    }
}
