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
    var $icon = $("#sidebarToggle i.fa");

    // When the sidebarToggle button is pressed will toggle the hide-sidebar class as necessary.
    // Also will change the toggle button text depending on the state of the hide-sidebar
    $("#sidebarToggle").on("click", function () {
        // ToggleClass adds class if doesnt exist or removes if it does
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-chevron-circle-left");
            $icon.removeClass("fa-chevron-circle-right");
        } else {
            $icon.addClass("fa-chevron-circle-left");
            $icon.removeClass("fa-chevron-circle-right");
        }
    });
})();