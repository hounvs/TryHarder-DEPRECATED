function HideAllRoleTables()
{
    // Get Role tables
    var tableList = $(".roleTable");
    // Hide all tables
    tableList.hide();
}

function ShowTable(dropDownList, event) {
    var temp = event;
    dropDownList = dropDownList["0"];
    // Get roleGroup Dropdown value
    var selectedRole = dropDownList.options[dropDownList.selectedIndex].innerHTML;
    // Hide all tables
    HideAllRoleTables();
    // Un-hide desired table
    $("#" + selectedRole + "-Table").show(1000, "easeOutQuad", null);
}

(
    HideAllRoleTables()
);