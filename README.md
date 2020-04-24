# Blazor Js Fast Data Exchanger

![](https://placehold.it/15/4747d1/000000?text=+) 
If you like my blazor works and want to see more open sourced repos please support me with [paypal donation](https://www.paypal.me/VakhtangiAbashidze/10)
![](https://placehold.it/15/4747d1/000000?text=+) 

![](https://placehold.it/15/00e600/000000?text=+) 
Please send [email](mailto:VakhtangiAbashidze@gmail.com) if you consider to **hire me**.
![](https://placehold.it/15/00e600/000000?text=+)     


![](https://placehold.it/15/ffffff/000000?text=+)   


Library is available on [nuget](https://www.nuget.org/packages/BlazorJsFastDataExchanger)

After installing package please add bellow script to your index.html

```<script src="_content/BlazorJsFastDataExchanger/BJSFDEJsInterop.js"></script>```

![](https://placehold.it/15/ffffff/000000?text=+)  

In some scenarios you need to have **heavy communication** between blazor and Javascript.

Using built-in JS interop sometimes **isn't fast enough**.

This repo uses low level API (mono wasm js bindings, unmarshalled calls and etc) and achieves about **40 times faster** data exchange.

Library is simple, there are given only two metods **SetData** and **GetData**, transport data type is **string** and any object if they aren't strings should be serialized/deserialized, including binary data.

For now string shows best performance but it can be changed and in the future we may add another data types support too.

You can send data using this library, **then access it from your own JS Interop code and
manipulate data as you like** in js side and then get back result using this lib.

To achieve this flexibility we use **variable name** which is identifer to find data, with different variable names we can have any amount of parallel processing and be sure data will not be messed up.

```
 //sending string to js
 JsFastDataExchanger.SetData("myData1",JsMessage); //this is just faster way to send data to js side

 // doing some operation on this data in js side
 _LocalJsInterop.ProcessData("myData1"); //this is your own js interop code and you (developer) decide what to do with data

 //get back processed data
 JsFastDataExchanger.GetData("myData1") //this is just faster way for get data from js side
```

![](https://placehold.it/15/ffffff/000000?text=+)  
It is not necessary to use this sequence, you can just GetData or SetData following your business logic needs.


There is another [repo](https://github.com/Lupusa87/BlazorJsFastDataExchangerDemo) which is demonstarting difference between regular and advanced JS Interop.

This demo is sending text, expanding it 100000 times, js local interop is reversing it and geting back result, repoting prformance in console.

There should be also referenced small helper [repo](https://github.com/Lupusa87/BlazorWindowHelper) to see performance report in browser's console

![](https://placehold.it/15/ffffff/000000?text=+)  
**Hope you will find this helpful.**

![](https://placehold.it/15/ffffff/000000?text=+)  
**PRs are velcome.**


![image](https://raw.githubusercontent.com/Lupusa87/BlazorJsFastDataExchanger/master/fast.png)
![](https://placehold.it/15/ffffff/000000?text=+)   
![image](https://raw.githubusercontent.com/Lupusa87/BlazorJsFastDataExchanger/master/slow.png)


