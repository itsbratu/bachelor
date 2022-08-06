function [probabilitate_zaruri , probabilitate_zaruri_binopdf] = zaruri_binornd(N=5000)
  p = 1 / 3;
  nr_zaruri_totale = 5;
  nr_zaruri_asteptate = 2;
  x = binornd(nr_zaruri_totale , p , 1 , N);
  cazuri_favorabile = 0;
  for i = 1:5000
    if nr_zaruri_asteptate == x(i)
      cazuri_favorabile = cazuri_favorabile + 1;
    endif
  endfor
  probabilitate_zaruri = cazuri_favorabile / N
  probabilitate_zaruri_binopdf = binopdf(2 , nr_zaruri_totale , p)
end