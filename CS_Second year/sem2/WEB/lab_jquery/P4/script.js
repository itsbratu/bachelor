class Produs {
  constructor(fruct, pret, cantitate) {
    this.fruct = fruct;
    this.pret = pret;
    this.cantitate = cantitate;
  }
}

const produse = [
  new Produs("Portocale", 3, 12),
  new Produs("Pepene", 10 , 29),
  new Produs("Mere", 3, 8),
  new Produs("Ananas", 1, 21),
  new Produs("Banane", 9, 8),
];

const init = () => {
  $("table").html("");
  let data = {};

  Object.getOwnPropertyNames(produse[0]).forEach((pr) => {
    data[pr] = produse.map((p) => p[pr]);
  });

  for (const [key, value] of Object.entries(data)) {
    let tr = $("<tr></tr>");
    tr.append(`<th onclick="handleSort('${key}')">${key.toUpperCase()}</th>`);
    value.forEach((v) => {
      tr.append(`<td>${v}</td>`);
    });
    $("table").append(tr);
  }
};

const handleSort = (key) => {
  produse.sort((a, b) => {
    if (typeof a[key.toLowerCase()] === "string") {
      var x = a[key.toLowerCase()];
      var y = b[key.toLowerCase()];
      if (x == y) {
        return 0;
      }
      return x > y ? 1 : -1;
    } else {
      return a[key.toLowerCase()] - b[key.toLowerCase()];
    }
  });
  init();
};

init();
