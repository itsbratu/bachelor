function out=double_factorial(n)
  out=1;
  if mod(n,2) ==0
    first=2;
  else
    first=1;
  end
  for step=first:2:n
    out = out*step;
  endfor
end