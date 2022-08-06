function problema()
  #a
  pkg load statistics
  cazuri_favorabile_a = 0;
  cazuri_favorabile_b = 0;
  valori_Z = zeros(1 , 1000);
  for i=1:1000
    X = unifrnd(1 , 2);
    Y = unifrnd(-1 , 1);
    Z = X + Y;
    valori_Z(i) = Z;
    if X > 1.5 && Y < 0.5
       cazuri_favorabile_a++;
    endif
    if power(Z , 2) > 0.25
      cazuri_favorabile_b++;
    endif
  endfor
  cazuri_favorabile_a / 1000
  cazuri_favorabile_b / 1000
  
  #b
  (1 - unifcdf(1.5 , 1 , 2))*(unifcdf(0.5 , -1 , 1))
  
  #c
  clf; hold on;
  histograma_c = hist(valori_Z , 0:3 , 7);
  bar(0:3 , histograma_c / 1000 , 'hist' , 'FaceColor' , 'b');
  legend('frecventa relativa')
endfunction