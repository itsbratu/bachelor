function monteCarlo(g , a , b , m , nr_pct)
   clf; hold on;
   x = unifrnd(a , b , 1 , nr_pct);
   y = unifrnd(0 , m , 1 , nr_pct);
   fplot(g , [a , b] , 'linewidth' , 2);
   plot(x(y<g(x)),y(y<g(x)),'%r','MarkerSize',10);
   plot(x(y>g(x)),y(y>g(x)),'%b','MarkerSize',10);
   
end