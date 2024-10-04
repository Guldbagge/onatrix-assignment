document.addEventListener("DOMContentLoaded", function () {
    console.log("JavaScript Loaded");

    var scrollPosition = sessionStorage.getItem("scroll-position");
    if (scrollPosition) {
        console.log("Restoring scroll position:", scrollPosition);
        window.scrollTo(0, parseInt(scrollPosition, 10));
        sessionStorage.removeItem("scroll-position");
    }

    const contactForm = document.getElementById("contact-form");
    if (contactForm) {
        contactForm.onsubmit = function () {
            console.log("Saving scroll position:", window.scrollY);
            sessionStorage.setItem("scroll-position", window.scrollY);
            document.getElementById('spinner').style.display = 'block';
        };
    }

    const searchIcon = document.querySelector('.search-icon a');
    const searchOverlay = document.querySelector('.search-overlay');
    const closeSearch = document.querySelector('.close-search');

    if (searchIcon) {
        searchIcon.addEventListener('click', function (e) {
            e.preventDefault();
            if (searchOverlay) {
                searchOverlay.classList.add('active');
            }
        });
    }

    if (closeSearch) {
        closeSearch.addEventListener('click', function () {
            if (searchOverlay) {
                searchOverlay.classList.remove('active');
            }
        });
    }
});
