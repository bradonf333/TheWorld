// Self executing anonymous function or an immediately invoked function expression
(function () {

    var ele = $("#username");
    ele.text("Bradon Fredrickson");

    var main = $("#main");
    main.on("mouseenter", function () {
        main.style = "background-color: #888;";
    });

    main.on("mouseleave", function () {
        main.style = "";
    });
})();