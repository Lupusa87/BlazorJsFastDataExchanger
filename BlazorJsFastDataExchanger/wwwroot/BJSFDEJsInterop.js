//https://github.com/mono/mono/blob/master/sdks/wasm/src/binding_support.js 4/24/2020
//https://github.com/dotnet/aspnetcore/blob/master/src/Components/Web.JS/src/Platform/Mono/MonoPlatform.ts
window.BJSFDEJsFunctions = {
    BJSFDESetData: function (v, t) {
        this[BINDING.conv_string(v)] = BINDING.conv_string(t);
        return true;
    },
    BJSFDEGetData: function (v) {
        var variableName = BINDING.conv_string(v);
        var result = this[variableName]
        //this[variableName] = null;
        delete this[variableName];
        return BINDING.js_to_mono_obj(result);
    },
};
