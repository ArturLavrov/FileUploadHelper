var uploadImageHelper = (function () {
    var selectedFile;
    var cardsPlaceHolder;
    return {
        fileSelection: function () {
            var selectedfile = $('#file')[0].files[0];
            selectedFile = selectedfile;
            document.getElementById("filefield").value = selectedfile.name;

        },
        uploadFile: function (file) {
            var photoPlace = document.getElementById("photocard");
            if (!file.length) {
                photoPlace.innerHTML = "<p>No files selected!</p>";
            } else {
                selectedFile = file;
                photoPlace.innerHTML = "";
                for (var i = 0; i < file.length; i++) {
                    var img = document.createElement("img");
                    img.src = window.URL.createObjectURL(file[i]);
                    img.height = 200;
                    img.weight = 150;
                    img.onload = function () {
                        window.URL.revokeObjectURL(this.src);
                    }
                    photoPlace.appendChild(img);
                    var fileName = document.createElement("p");
                    fileName.innerHTML = file[i].name;
                    var fileSize = document.createElement("p");
                    fileSize.innerHTML = file[i].size;
                    photoPlace.appendChild(fileName);
                    photoPlace.appendChild(fileSize);
                }
            }
        },
        uploadFiles: function (files) {
            cardsPlaceHolder = document.getElementById("cardPlaceHolder");
            if (!files.length) {
                cardsPlaceHolder.innerHTML = "<p>No files selected!</p>";
            } else {
                cardsPlaceHolder.innerHTML = "";
                var list = document.createElement("ul");
                list.className = "list-inline";
                cardsPlaceHolder.appendChild(list);
                for (var i = 0; i < files.length; i++) {

                    var li = document.createElement("li");
                    list.appendChild(li);

                    var thumbnailDiv = document.createElement("div");
                    thumbnailDiv.className = "thumbnail";
                    thumbnailDiv.id = i;

                    var img = document.createElement("img");
                    img.src = window.URL.createObjectURL(files[i]);
                    img.height = 100;
                    img.onload = function () {
                        window.URL.revokeObjectURL(this.src);
                    }

                    var infoDiv = document.createElement("div");
                    infoDiv.className = "caption";
                    var fileName = document.createElement("p");
                    fileName.innerHTML = "Name: " + files[i].name;
                    var fileSize = document.createElement("p");
                    fileSize.innerHTML = "File size: " + files[i].size;
                    infoDiv.appendChild(fileName);
                    infoDiv.appendChild(fileSize);

                    thumbnailDiv.appendChild(img);
                    thumbnailDiv.appendChild(infoDiv);
                    li.appendChild(thumbnailDiv);
                }
            }
        },
        getFileName: function () {
            return selectedFile.name;
        },

        getFileSize: function () {
            return selectedFile.size;
        },
        getFileExtension: function () {

        }
    }
})();