bits 32

global start        

extern exit , printf           
import exit msvcrt.dll    
import printf msvcrt.dll     

segment data use32 class=data
    s db "aa222%%%%%)()()vvvvvv$$$$" , 0 
    len equ ($-s)
    vocale db "aeiouAEIOU" , 0
    len_vocale equ ($-vocale)
    consoane db "qwrtypsdfghjklzxcvbnmQWRTYPSDFGHJKLZXCVBNM" , 0
    len_consoane equ ($-consoane)
    cifre db "0123456789" , 0
    len_cifre equ ($-cifre)
    nr_vocale dd 0
    nr_consoane dd 0
    nr_cifre dd 0
    nr_speciale dd 0 
    copie_offset dd -1
    copie_contor dd -1
    afisare_mesaj db "Sirul de caractere are : %d vocale , %d consoane , %d cifre , respectiv %d caractere speciale" , 0
    format db "%d" , 0

segment code use32 class=code
    start:
        
        mov esi , s
        mov ecx , len
        dec ecx 
        
        parcurgere:
            xor eax , eax
            xor ebx , ebx 
            lodsb
            mov bl , al
            mov dword[copie_offset] , esi 
            mov dword[copie_contor] , ecx 
            
            mov esi , vocale
            mov ecx , len_vocale
            dec ecx 
                parcurgere_vocale:
                    lodsb
                    cmp al , bl 
                    je vowel_next
                loop parcurgere_vocale
            mov esi , consoane
            mov ecx , len_consoane
            dec ecx
                parcurgere_consoane:
                    lodsb
                    cmp al , bl 
                    je consonant_next
                loop parcurgere_consoane
            mov esi , cifre
            mov ecx , len_cifre
            dec ecx 
                parcurgere_cifre:
                    lodsb 
                    cmp al , bl 
                    je digit_next
                loop parcurgere_cifre
            
            xor ebx , ebx 
            mov ebx , dword[nr_speciale]
            inc ebx
            mov dword[nr_speciale] , ebx
            jmp final

            revenire:
                loop parcurgere
                jmp end_parcurgere
            
            vowel_next:
                xor ebx , ebx
                mov ebx , dword[nr_vocale]
                inc ebx
                mov dword[nr_vocale] , ebx
                jmp final
            consonant_next:
                xor ebx , ebx 
                mov ebx , dword[nr_consoane]
                inc ebx
                mov dword[nr_consoane] , ebx
                jmp final
            digit_next:
                xor ebx , ebx
                mov ebx , dword[nr_cifre]
                inc ebx
                mov dword[nr_cifre] , ebx
                jmp final
            
            final:
                mov ecx , dword[copie_contor]
                mov esi , dword[copie_offset]
                cmp ecx , 0
                jg revenire
        
        end_parcurgere:
            push dword [nr_speciale]
            push dword [nr_cifre]
            push dword [nr_consoane]
            push dword [nr_vocale]
            push dword afisare_mesaj
            call [printf]
            add esp , 4*5
        
        
        push    dword 0      
        call    [exit]       
