function loto(nr_repetari) 
  p = sum(hygepdf(3 : 6, 49, 6, 6));
  x = geornd(p, 1, nr_repetari);

  prob_estim = mean(x >= 10)
  prob_teor = 1 - sum(geopdf(0 : 9, p))

end
