function simulari_deplasari_axa(nr_simulari , nr_pasi , prob_deplasare)
  pozitii_finale = zeros(1,nr_simulari);
  nr_pasi_dreapta = zeros(1 , nr_simulari);
  for i=1:nr_simulari
    [pozitii , pasi_dreapta] = deplasare_punct(nr_pasi , prob_deplasare);
    nr_pasi_dreapta(i) = pasi_dreapta;
    pozitii_finale(i) = pozitii(end);
  endfor
  N=histc(pozitii_finale,-nr_pasi:nr_pasi);
  bar(-nr_pasi:nr_pasi,N/nr_simulari,'hist','FaceColor','b');
  set(gca,'XTick',-nr_pasi:nr_pasi); grid on;
  xlim([-nr_pasi-1 nr_pasi+1]);
  fprintf('Poz. finale cele mai frecvente: %d.\n',find(N==max(N))-nr_pasi-1);
  fprintf('Media nr pasi dreapta este : %f. \n' , mean(nr_pasi_dreapta));