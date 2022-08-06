function X=gen_aleatoare(x , p , n)
  sums = cumsum(p);
  
  for i = 1:n
    g = rand;
    index = 1;
    while g > sums(index)
      index++;
    endwhile
    X(i) = x(index);
  endfor
  
end  