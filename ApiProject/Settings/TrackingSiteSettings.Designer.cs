﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Task3.Settings {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
    internal sealed partial class TrackingSiteSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static TrackingSiteSettings defaultInstance = ((TrackingSiteSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new TrackingSiteSettings())));
        
        public static TrackingSiteSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://bd08355c73ae45fa9e1ff1ef6389a611.api.mockbin.io/")]
        public string Url {
            get {
                return ((string)(this["Url"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("username")]
        public string Username {
            get {
                return ((string)(this["Username"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("username2")]
        public string Username2 {
            get {
                return ((string)(this["Username2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public string AccountId {
            get {
                return ((string)(this["AccountId"]));
            }
        }
    }
}
