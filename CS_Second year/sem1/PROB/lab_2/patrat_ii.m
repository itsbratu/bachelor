function probabilitate=patrat_ii(N=500)
%N=numarul de puncte generate
  clf;hold on;axis square;
  rectangle('Position',[0 0 1 1]);
  A = [0 , 0];
  B = [1 , 0];
  C = [1 , 1];
  D = [0 , 1];
  O = [0.5 , 0.5];
  cazuri_fav_a = 0;
for i=1:N
  x=rand;y=rand;
  P = [x , y];
  distPA = pdist([A;P]);
  distPB = pdist([B;P]);
  distPC = pdist([C;P]);
  distPD = pdist([D;P]);
  distPO = pdist([O;P]);
  if(distPO < distPA && distPO < distPB...
  && distPO < distPC && distPO < distPD)
    cazuri_fav_a++;
    plot(x,y,'pb','MarkerSize',7,'MarkerFaceColor','r');
  endif
endfor
  probabilitate = cazuri_fav_a/N;
end