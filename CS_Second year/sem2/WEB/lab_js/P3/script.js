const mainSection = document.querySelector("#main-section");
const FRUITS_NUMBER = 16;
var level = 1;
var boardSize = 2;

let hasFlippedCard = false;
let lockBoard = false;
let firstCard, secondCard;

const questionCard = ["img/question-mark.png", "question"];
const cardsMapper = {
  0 : ["img/apple.png", "apple"],
  1 : ["img/strawberry.png", "strawberry"],
  2 : ["img/bananas.png", "bananas"],
  3 : ["img/mango.png", "mango"],
  4 : ["img/orange.png", "orange"],
  5 : ["img/peach.png", "peach"],
  6 : ["img/lime.png", "lime"],
  7 : ["img/pomegranate.png", "pomegranate"],
  8 : ["img/plum.png", "plum"],
  9 : ["img/cherry.png", "cherry"],
  10 : ["img/pineapple.png", "pineapple"],
  11 : ["img/coconut.png", "coconut"],
  12 : ["img/avocado.png", "avocado"],
  13 : ["img/apricot.png", "apricot"],
  14 : ["img/blueberry.png", "blueberry"],
  15 : ["img/kiwi.png", "kiwi"],
};

function setLevel(){
  document.querySelector("#title").innerHTML = `Level ${level}`;
}

function getRandomInt(min, max) {
  min = Math.ceil(min);
  max = Math.floor(max);
  return Math.floor(Math.random() * (max - min) + min); 
}

function generateWantedFruits(){
  const selectedFruits = [];
  while(selectedFruits.length != boardSize){
    var generatedNumber = getRandomInt(0, FRUITS_NUMBER);
    while(selectedFruits.includes(generatedNumber)){
      generatedNumber = getRandomInt(0, FRUITS_NUMBER);
    } 
    selectedFruits.push(generatedNumber);
  }
  return selectedFruits;
}

function generateTable(selectedFruits){
  selectedFruits.forEach((value) => {
    var gameCard = document.createElement("div");
    gameCard.setAttribute('class', 'memory-card');
    gameCard.setAttribute('data-framework', cardsMapper[value][1])

    var frontFace = document.createElement("img");
    frontFace.setAttribute('src', cardsMapper[value][0]);
    frontFace.setAttribute('alt', cardsMapper[value][1]);
    frontFace.setAttribute('class', 'front-face');

    var backFace = document.createElement("img");
    backFace.setAttribute('src', questionCard[0]);
    backFace.setAttribute('alt', questionCard[1]);
    backFace.setAttribute('class', 'back-face');

    gameCard.appendChild(frontFace);
    gameCard.appendChild(backFace);
    mainSection.appendChild(gameCard);
    mainSection.appendChild(gameCard.cloneNode(true));
  })
} 
function solve(){
  setLevel();
  generateTable(generateWantedFruits());
  const cards = document.querySelectorAll('.memory-card');
  shuffle(cards).forEach(card => {
    card.addEventListener('click', flipCard);
    card.addEventListener('click', () => {
      console.log(card.hasAttribute('data-framework'));
    })
  });
}

function shuffle(cards) {
  cards.forEach(card => {
    let randomPos = Math.floor(Math.random() * 12);
    card.style.order = randomPos;
  });
  return cards;
}

function clearElements() {
  level += 1;
  document.querySelector("#main-section").innerHTML = "";
}

function flipCard() {
  if (lockBoard) return;
  if (this === firstCard) return;

  this.classList.add('flip');

  if (!hasFlippedCard) {
    hasFlippedCard = true;
    firstCard = this;

    return;
  }

  secondCard = this;

  checkForMatch();
}

function checkForMatch() {
  let isMatch = firstCard.dataset.framework === secondCard.dataset.framework;

  isMatch ? disableCards() : unflipCards();
}

function disableCards() {
  firstCard.removeEventListener('click', flipCard);
  secondCard.removeEventListener('click', flipCard);
  firstCard.removeAttribute('data-framework');
  secondCard.removeAttribute('data-framework');

  var continuePlaying = false;
  const cards = document.querySelectorAll('.memory-card');
  cards.forEach((card) => {
    if(card.hasAttribute('data-framework')){
      continuePlaying = true;
    }
  })
  if(continuePlaying){
    resetBoard();
  }else{
    setTimeout(() => {
      resetBoard();
      clearElements();
      boardSize = boardSize * 2;
      if(level != 5){
        solve();
      }else{
        alert("Congrats, you won!")
      }
    },250)
  }
}

function unflipCards() {
  lockBoard = true;
  
  setTimeout(() => {
    firstCard.classList.remove('flip');
    secondCard.classList.remove('flip');

    resetBoard();
  }, 1000);
}

function resetBoard() {
  [hasFlippedCard, lockBoard] = [false, false];
  [firstCard, secondCard] = [null, null];
}

mainSection.addEventListener('load', solve());