// Global using directives

global using System;
global using Telegram.Bot.Types;
global using System.Runtime.Serialization;

#if !NET8_0_OR_GREATER
global using Newtonsoft.Json;
global using Newtonsoft.Json.Serialization;
#else
global using System.Text.Json;
global using System.Text.Json.Serialization;
#endif
