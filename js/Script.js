(function () {
    'user strict';

    window.onload = function () {

        var query = window.location.href,
            nav = document.querySelectorAll('nav ul li');

        if (query.match(/om-os$/) !== null) nav[1].setAttribute('class', 'selected');
        if (query.match(/kategorier$/) !== null) nav[2].setAttribute('class', 'selected');
        if (query.match(/produkter$/) !== null) nav[3].setAttribute('class', 'selected');
        if (query.match(/support$/) !== null) nav[4].setAttribute('class', 'selected');
        if (query.match(/partnere$/) !== null) nav[5].setAttribute('class', 'selected');
        if (query.match(/dokumenter$/) !== null) nav[6].setAttribute('class', 'selected');
        if (query.match(/nyheder$/) !== null) nav[7].setAttribute('class', 'selected');
    }
})()