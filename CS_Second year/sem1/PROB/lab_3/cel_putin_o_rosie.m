function probabilitate_estimata=cel_putin_o_rosie(nr_sim=5000)
  urna = ['r' 'r' 'r' 'r' 'r' 'a' 'a' 'a' 'v' 'v'];
  count_cel_putin_o_rosie = 0;
  for i=1:nr_sim
    extragere = randsample(urna , 3 , replacement = false);
    if(extragere(1) == 'r' || extragere(2) == 'r' || extragere(3) == 'r')
       count_cel_putin_o_rosie++;
    endif  
  endfor  
probabilitate_estimata = count_cel_putin_o_rosie / nr_sim;