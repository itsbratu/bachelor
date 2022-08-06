const items = document.querySelectorAll(".item")
const dots = document.querySelectorAll(".dot")

const prevButton = document.querySelector("button#prev")
const nextButton = document.querySelector("button#next")

var position = 0;

const moveDelay = (func) => {
    const interval = setInterval(func, 2000);
    return interval;
}

const hideItems = () => {
    for (const item of items) {
        item.classList.remove("active")
        item.classList.add("hidden")
    }
}

const moveToNextItem = (e) => {
    hideItems()

    const numberOfItems = items.length
    if (position == numberOfItems - 1) {
        position = 0;
    } else {
        position++;
    }

    items[position].classList.add("active")

    dots[position].classList.add("selected")
    dots[position].checked = true;
}


const moveToPreviousItem = (e) => {
    hideItems()

    if (position == 0) {
        position = items.length - 1;
    } else {
        position--;
    }

    items[position].classList.add("active")

    dots[position].classList.add("selected")
    dots[position].checked = true
}

prevButton.addEventListener("click", moveToPreviousItem)
nextButton.addEventListener("click", moveToNextItem)
moveDelay(moveToNextItem)