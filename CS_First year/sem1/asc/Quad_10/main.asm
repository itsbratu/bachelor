bits 32

global start        

extern exit , printf           
import exit msvcrt.dll    
import printf msvcrt.dll     

segment data use32 class=data
    s dq 85aa145cf23ca213h
    bit db -1
    nr dd 0
    copie dd -1
    mesaj_afisare db "Numarul de 10 din s este : %d" , 0
    
segment code use32 class=code
    start:
    
        mov esi , s 
        mov ecx , 2 
        
        parcurgere:
            lodsd
            mov dword[copie] , ecx 
            mov ecx , 32
                shiftare:
                    xor ebx , ebx 
                    shr eax , 1
                    adc ebx , 0 
                    cmp ebx , 1
                    je might_be
                    
                    xor edx , edx 
                    mov byte[bit] , dl
                    jmp final
                    
                    might_be:
                        xor edx , edx 
                        mov dl , byte[bit]
                        cmp dl , 0
                        je increment
                    
                    xor edx , edx 
                    mov dl , -1
                    mov byte[bit] , dl
                    jmp final
                   
                    increment:
                        xor edx , edx 
                        mov edx ,dword[nr]
                        inc edx 
                        mov dword[nr] , edx
                    
                    xor edx , edx 
                    mov dl , -1
                    mov byte[bit] , dl            
                    final:
                
                loop shiftare
            mov ecx , dword[copie]
        
        loop parcurgere
        
        xor eax , eax 
        mov eax , dword[nr]
        
        push dword eax
        push dword mesaj_afisare
        call [printf]
        add esp , 4 * 2
 
        push    dword 0      
        call    [exit]       
