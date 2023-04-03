//function screenshot() {
//    html2canvas(document.body).then(function (canvas) {   //TO DISPLAY IMAGE IN DOCUMENT BODY ITSELF
//        document.body.appendChild(canvas);
//    });
//}


//FOR DOWNLOADING IMAGE
function capture() {


    html2canvas(document.body).then(canvas => {
        let a = document.createElement("a");
        a.download = "image.png";
        a.href = canvas.toDataURL("image/png");
        a.click();
    });
}