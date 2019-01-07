#FileUploadHelper
[![Build Status](https://dev.azure.com/arturstylus/FileUploadHelper/_apis/build/status/ArturLavrov.FileUploadHelper?branchName=master)](https://dev.azure.com/arturstylus/FileUploadHelper/_build/latest?definitionId=1?branchName=master)


###Short Overview
AspNetUploadHelpers-this is the set of ASP.NET MVC Helpers for uploading image, images or other file to your web-application 
without any client-side code.
###How to use?
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
###What else?
If you want to use other helpers, mechanic is the same.For example you can use **UploadImageWithThumbnail**. This is useful when you need to upload user profile image
```c#
@Html.UploadImageWithThumbnail("UploadImage","Home")
```
![alt tag](https://s7.postimg.org/tv81tz7uz/Upload_Avatar.png)<br>
If you want to upload multiple images with thumbnails use **UploadImagesWithThumbnail**:
```c#
@Html.UploadImagesWithThumbnail ("UploadImages", "Home")
```
![alt tag](https://s7.postimg.org/3oz75yuvv/Upload_Images.png)<br>
