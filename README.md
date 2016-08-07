#FileUploadHelper
<b><h3>Short Overview</h3></b>
AspNetUploadHelpers-this is the set of ASP.NET MVC Helpers for uploading image, images or other file to your web-application 
without any client-side code.
<b><h3>How to use?</h3></b>
Using this helpers is pretty simple. Let’s try to figure out on simple example.
Suppose you need to upload single image. You should just write familiar to you Razor helper’s syntax:
```c#
@Html.UploadImage("UploadImage","Home")
```
Where UploadImage is your action and Home is your controller.
And you get this:<br>
![alt tag](https://s8.postimg.org/c4whbsoyd/Upload_Image.png)<br>
Then browse image from your disk (in my case this is avatar.png), press OK and you will see:
![alt tag](https://s8.postimg.org/kycbl1kxx/Upload_Image_Action.png)<br>
Press Upload and your file will be upload. That’s all.
