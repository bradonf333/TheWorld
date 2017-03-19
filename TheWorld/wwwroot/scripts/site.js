﻿// Self executing anonymous function or an immediately invoked function expression
(function () {
    var ele = document.getElementById("username");
    ele.innerHTML = "Bradon Fredrickson";

    var main = document.getElementById("main");
    main.onmouseenter = function () {
        main.style.backgroundColor = "#888";
    };

    main.onmouseleave = function () {
        main.style.backgroundColor = "";
    };
})();