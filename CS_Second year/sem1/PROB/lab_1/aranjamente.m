function A=aranjamente(v , k)
  C = nchoosek(v ,k)
  A = [];
  for i=1:size(C)(1)
    D = perms(C(i,:));
    A = [A;D];
  endfor
end