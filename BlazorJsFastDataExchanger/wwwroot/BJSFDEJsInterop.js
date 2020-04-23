var GlobalExchangeData='empty';

window.BJSFDEJsFunctions = {
    BJSFDESendData: function (t) {
        //GlobalExchangeData = new TextDecoder("utf-8").decode(Blazor.platform.toUint8Array(t));
        GlobalExchangeData = BINDING.conv_string(t);
        return true;
    },
    BJSFDERequestData: function () {
        Module.mono_call_static_method("[BlazorJsFastDataExchanger] BlazorJsFastDataExchanger.JsFastDataExchanger:HandleMessage", [GlobalExchangeData]);
    },
};
