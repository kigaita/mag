(function() {

    $("#teams").DataTable({
        "ajax": "/Ajax/GetTeams"
    });

})();