function zaruri_sume(nr_aruncari)
  sume_posibile = 4 : 24;
  
  zaruri = randi(6, 4, nr_aruncari);
  sume_sim = sum(zaruri);
  frecv_abs = hist(sume_sim, sume_posibile);

  sume_frecv_abs = [sume_posibile; frecv_abs]
  
end