/// <reference path="typings/globals/jquery/index.d.ts" />


$(document).ready(function(){
  const cards = $(".memory-card");

  $(".memory-card").bind("click", flipCard);

  cards.each(function() {
    let randomPos = Math.floor(Math.random() * 12);
    $(this).css("order", randomPos);
  });
});

let hasFlippedCard = false;
let lockBoard = false;
let firstCard, secondCard;

function flipCard() {
  if (lockBoard) return;
  if (this === firstCard) return;

  $(this).addClass("flip")

  if (!hasFlippedCard) {
    // first click
    hasFlippedCard = true;
    firstCard = this;

    return;
  }

  // second click
  secondCard = this;

  checkForMatch();
}

function checkForMatch() {
  l 

function unflipCards() {
  lockBoard = true;

  setTimeout(() => {
    $(firstCard).removeClass("flip");
    $(secondCard).removeClass("flip");

    resetBoard();
  }, 1500);
}

function resetBoard() {
  [hasFlippedCard, lockBoard] = [false, false];
  [firstCard, secondCard] = [null, null];
}