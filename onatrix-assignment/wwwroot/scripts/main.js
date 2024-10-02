document.addEventListener("DOMContentLoaded", function () {
    console.log("JavaScript Loaded");

    
    var scrollPosition = sessionStorage.getItem("scroll-position");
    if (scrollPosition) {
        console.log("Restoring scroll position:", scrollPosition);
        window.scrollTo(0, parseInt(scrollPosition, 10));
        sessionStorage.removeItem("scroll-position"); 
    }

    document.getElementById("contact-form").onsubmit = function () {
        console.log("Saving scroll position:", window.scrollY);
        
        sessionStorage.setItem("scroll-position", window.scrollY);
    };
});

document.getElementById('contact-form').addEventListener('submit', function () {

    document.getElementById('spinner').style.display = 'block';
});