function probabilitate=patrat_i(N=500)
%N=numarul de puncte generate
  clf;hold on;axis square;
  rectangle('Position',[0 0 1 1]);
  C = [0.5 , 0.5];
  cazuri_fav_a = 0;
for i=1:N
  x=rand;y=rand;
  P = [x , y];
  dist = pdist([C;P]);
  if(dist < 0.5)
    cazuri_fav_a++;
    plot(x,y,'pb','MarkerSize',7,'MarkerFaceColor','r');
  endif
endfor
  probabilitate = cazuri_fav_a/N;
end