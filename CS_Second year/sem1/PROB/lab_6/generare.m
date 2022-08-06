% normrnd - pentru a genera numere aleatoare conform distributiei normale
% normrnd(m , s , l , c)
% m - valoarea medie
% s - deviatia standard (sigma)
% l - numar de linii
% c - numar de coloane

clf;hold on;

nr_bare = 10;
x = normrnd(165 , 10 , 1 , 1000);
[nn , xx] = hist(x , nr_bare);
hist(x , xx , nr_bare / (max(x) - min(x)));

diviziune = linspace(min(x) , max(x) , 1000);
valori = normpdf(diviziune , 165 , 10);
plot(diviziune , valori , '-r' , 'linewidth' , 3);