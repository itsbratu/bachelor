function X = nrAleatorExp(lambda , n)
  u = rand(1,n);
  X = -1/lambda * log(1-u);