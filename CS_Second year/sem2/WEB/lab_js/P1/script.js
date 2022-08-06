function move(l1, l2) {
    var text = l1.options[l1.selectedIndex].text;
    l1.remove(l1.selectedIndex);

    var option = document.createElement("option");
    option.value = "value";
    option.text = text;
    l2.appendChild(option);
}