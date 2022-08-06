var position = 0;

const init = () => {
  $(".item").each((item) => {
    $(".dots").append(`<input class="dot" type="radio" name="dot" />`);
  });
  $($(".dot").get(0)).addClass("selected-dot");
  $($(".dot").get(0)).prop("checked", true);
};

init();

const hideItems = () => {
  $(".item").each(function (index) {
    $(this).removeClass("active");
    $(this).addClass("hidden");
  });
};

const moveToNextItem = (_) => {
  hideItems();

  const numberOfItems = $(".item").length;
  if (position == numberOfItems - 1) {
    position = 0;
  } else {
    position++;
  }

  $($(".item").get(position)).addClass("active");
};

const moveToPreviousItem = (_) => {
  hideItems();

  if (position == 0) {
    position = $(".item").length - 1;
  } else {
    position--;
  }

  $($(".item").get(position)).addClass("active");
};

$("button#prev").click(moveToPreviousItem);
$("button#next").click(moveToNextItem);

setInterval(moveToNextItem, 4000);
