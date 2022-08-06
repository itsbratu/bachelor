function probabilitate=patrat_iii(N=500)
  clf;hold on;axis square;
  rectangle('Position' , [0 0 1 1]);
  A = [0 , 0];
  B = [1 , 0];
  C = [1 , 1];
  D = [0 , 1];
  O = [0.5 , 0.5];
  cazuri_fav = 0;
  for i=1:N
    x = rand;
    y = rand;
    P = [x , y];
    distPA = pdist([A;P]);
    distPB = pdist([B;P]);
    distPC = pdist([C;P]);
    distPD = pdist([D;P]);
    cosAOB = (((distPA * distPA + distPB * distPB) -1) / (2*distPA*distPB));
    cosBOC = (((distPB * distPB + distPC * distPC) -1) / (2*distPB*distPC));
    cosCOD = (((distPC * distPC + distPD * distPD) -1) / (2*distPC*distPD));
    cosDOA = (((distPD * distPD + distPA * distPA) -1) / (2*distPD*distPA));
    if((cosAOB < 0 && cosBOC < 0 && cosCOD > 0 && cosDOA > 0) || ...
      (cosAOB < 0 && cosBOC > 0 && cosCOD < 0 && cosDOA > 0) || ...
      (cosAOB < 0 && cosBOC > 0 && cosCOD > 0 && cosDOA < 0) || ...
      (cosAOB > 0 && cosBOC < 0 && cosCOD < 0 && cosDOA > 0) || ...
      (cosAOB > 0 && cosBOC < 0 && cosCOD > 0 && cosDOA < 0) || ...
      (cosAOB > 0 && cosBOC > 0 && cosCOD < 0 && cosDOA < 0))
        cazuri_fav = cazuri_fav + 1;
        plot(x , y , 'pb' , 'MarkerSize' , 7 , 'MarkerFaceColor' , 'r');
    endif
  endfor
  probabilitate = cazuri_fav / N;
end