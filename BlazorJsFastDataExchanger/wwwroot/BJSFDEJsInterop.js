//https://github.com/mono/mono/blob/master/sdks/wasm/src/binding_support.js 4/24/2020
//https://github.com/dotnet/aspnetcore/blob/master/src/Components/Web.JS/src/Platform/Mono/MonoPlatform.ts

window.BJSFDEJsFunctions = {
    SetStringData: function (v, t) {
        window[BINDING.conv_string(v)] = BINDING.conv_string(t);
        return true;
    },
    SetBinaryData: function (v, d) {
        window[BINDING.conv_string(v)] = Blazor.platform.toUint8Array(d);
        return true;
    },
    GetStringData: function (v) {
        var variableName = BINDING.conv_string(v);
        var result = window[variableName];
        delete window[variableName];
        return BINDING.js_to_mono_obj(result);
    },
    GetBinaryDataLenght: function (v) {
        var variableName = BINDING.conv_string(v);
        return window[variableName].byteLength;
    },
    GetBinaryData: function (v, d) {
        var variableName = BINDING.conv_string(v);
        var result = window[variableName];
        var destinationUint8Array = Blazor.platform.toUint8Array(d);
        destinationUint8Array.set(new Uint8Array(result));
        delete window[variableName];
        return true;
    },
    GetBinaryDataChunk: function (v, d, b) {
        var variableName = BINDING.conv_string(v);
        var bag = BINDING.conv_string(b);
        var bagArray = bag.split(',');
        var position = bagArray[0];
        var chunkSize = bagArray[1];

        var sourceUint8Array = new Uint8Array(window[variableName], position, chunkSize);

        var destinationUint8Array = Blazor.platform.toUint8Array(d);
        destinationUint8Array.set(sourceUint8Array, position);

        //console.log("js " + position);
        return true;
    },
    DeleteGlobalVariable: function (v)
    { 
        delete window[BINDING.conv_string(v)];
        return true;
    },
    CallDotNetMethod: function (pAssembly, pNamespace, pClass, pMethod, pArgs) {
        Module.mono_call_static_method("[" + pAssembly + "] " + pNamespace + "." + pClass + ":" + pMethod, [pArgs]);
        return true;
    },
    InvokeOnMessageAction: function (msg) {
        Module.mono_call_static_method("[BlazorJsFastDataExchanger] BlazorJsFastDataExchanger.JsFastDataExchanger:HandleMessage", [msg]);
        return true;
    },
    InvokeOnProgressAction: function (msg) {
        Module.mono_call_static_method("[BlazorJsFastDataExchanger] BlazorJsFastDataExchanger.JsFastDataExchanger:HandleProgress", [msg]);
        return true;
    },
};
