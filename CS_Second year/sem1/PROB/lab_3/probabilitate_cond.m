function probabilitate_estimata=probabilitate_cond(nr_sim=5000)
  urna = ['r' 'r' 'r' 'r' 'r' 'a' 'a' 'a' 'v' 'v'];
  count_cel_putin_o_rosie = 0;
  count_toate_rosii = 0;
  for i=1:nr_sim
    extragere = randsample(urna , 3 , replacement = false);
    if(extragere(1) == 'r' || extragere(2) == 'r' || extragere(3) == 'r')
       count_cel_putin_o_rosie++;
       if(extragere(1) == 'r' && extragere(2) == 'r' && extragere(3) == 'r')
          count_toate_rosii++; 
       endif  
    endif  
  endfor  
probabilitate_estimata = count_toate_rosii / count_cel_putin_o_rosie;