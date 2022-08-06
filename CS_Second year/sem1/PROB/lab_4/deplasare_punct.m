function [pozitii , count_right]=deplasare_punct(nr_pasi , prob_deplasare)
  pozitii = zeros(1 , nr_pasi+1);
  current_index = 0;
  count_right = 0;

  for i=1:nr_pasi
      x = rand;
      if x < prob_deplasare
        current_index = current_index + 1;
        count_right = count_right + 1;
        pozitii(i+1) = current_index; 
      endif
      if x > prob_deplasare
        current_index = current_index - 1;
        pozitii(i+1) = current_index;
      endif
  endfor
end