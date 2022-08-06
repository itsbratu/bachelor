function simulari_deplasari_cerc(nr_simulari , nr_pasi , prob_deplasare , nr_vortex)
  pozitii_finale = zeros(1,nr_simulari);
  for i=1:nr_simulari
    pozitii = deplasare_punct(nr_pasi , prob_deplasare);
    pozitii_finale(i) = mod(pozitii(end), nr_vortex);
  endfor
  N=histc(pozitii_finale,0:nr_vortex-1);
  bar(0:nr_vortex-1,N/nr_simulari,'hist','FaceColor','b');
  set(gca,'XTick',-nr_pasi:nr_pasi); grid on;
  xlim([-1 nr_vortex]);
  fprintf('Poz. finale cele mai frec  vente: %d.\n',find(N==max(N))-1);