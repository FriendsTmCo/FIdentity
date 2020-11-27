function hello() {
    var amountCurrent = document.getElementById("amount").value;
    var paid = document.getElementById("paid").value;
    var need = document.getElementById("need");

    if ((parseInt(amountCurrent) - parseInt(paid)).toString() !== "0") {
        need.value = (parseInt(amountCurrent) - parseInt(paid)).toString();
    } else {
        need.value = "0";
    }
}


function showImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#img').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}



function showImageBanner(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#imgBanner').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    } else {
        var validation = document.getElementById("bannerval");
        validation.innerHTML = "تصویر بنر را وارد کنید";
    }
}


var i = 0;
function Banner() {
    i++;
    var bannerSection = document.getElementById("banner");
    var imgBanner = document.getElementById("imgBanner");
    if (i % 2 !== 0) {
        bannerSection.style.display = "inline";
        imgBanner.style.display = "inline";
    } else {
        bannerSection.style.display = "none";
        imgBanner.style.display = "none";
    }
}

var banner = document.getElementById("bannerImage");
var content = document.getElementById("myImg");
function showBanner(src) {
    content.src = src;
    banner.style.display = "inline-block";
    banner.onclick = function () {
        banner.style.display = "none";
    }
}


(() => {
    var check = document.getElementById("isBanner");
    if (check.checked) {
        Banner();
    }
})();