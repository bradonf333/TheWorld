// Self executing anonymous function or an immediately invoked function expression
(function () {

    //var ele = $("#username");
    //ele.text("Bradon Fredrickson");

    //var main = $("#main");
    //main.on("mouseenter", function () {
    //    main.style = "background-color: #888;";
    //});

    //main.on("mouseleave", function () {
    //    main.style = "";
    //});

    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});

    // Using jQuery gets both these elements and puts them in a "wrapped set" of DOM elements
    var $sidebarAndWrapper = $("#sidebar,#wrapper");

    // When the sidebarToggle button is pressed will toggle the hide-sidebar class as necessary
    $("#sidebarToggle").on("click", function () {
        // ToggleClass adds class if doesnt exist or removes if it does
        $sidebarAndWrapper.toggleClass("hide-sidebar");
    });
})();