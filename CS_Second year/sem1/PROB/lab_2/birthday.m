function frecventa_relativ=birthday(nr_generari)

  nr_fav = 0;

  for i=1:nr_generari
    birthdays=randi(365 , 1 , 23);
    if length(unique(birthdays)) < 23
      nr_fav++;
    endif
  end

  frecventa_relativ = nr_fav/nr_generari;
end