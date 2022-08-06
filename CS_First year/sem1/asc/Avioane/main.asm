bits 32

global start        

extern exit           
extern printf
extern scanf    
import exit msvcrt.dll                         
import printf msvcrt.dll
import scanf msvcrt.dll

extern liniarizare

segment data use32 class=data
    n dd -1
    m dd -1
    format_n db "Va rugam cititi n : " , 0
    format_m db "Va rugam cititi m : " , 0
    format_avion db "Va rugam cititi indexul urmatorului avion : " , 0
    afisare_avion db "Avionul curent a fost bombardat la linia : % d si coloana : %d " , 0
    afisare_rezultat db "Au fost lovite %d avioane din %d , iar %d bombe si-au ratat tinta" , 0 
    format db "%d" , 0
    index dd -1
    copie dd -1
    bombardate dd 0
    sir1 times 100 db -1
    sir2 times 100 db -1
    bombe db 02h , 00h , 0Dh , 06h
    len_bombe equ ($-bombe)
    
    
segment code use32 class=code
    start:
        
        push dword format_n
        call [printf]
        add esp , 4
        
        push dword n
        push dword format
        call [scanf]
        add esp , 4*2
        
        push dword format_m
        call [printf]
        add esp , 4
        
        push dword m
        push dword format
        call [scanf]
        add esp , 4*2
        
        mov ecx , dword[m]
        
        parcurgere:
            mov dword[copie] , ecx
            push dword format_avion
            call [printf]
            add esp , 4 
            
            push dword index 
            push dword format
            call [scanf]
            add esp , 4*2
            
            xor ebx , ebx 
            xor ecx , ecx
            mov ebx , dword[index]
            mov esi , bombe 
            mov ecx , len_bombe
            
                gasire_bomba:
                    lodsb
                    cmp al , bl
                    je bombardat
                
                loop gasire_bomba
            
            jmp not_bombardat
            revenire1:
                mov ecx ,dword[copie]
                loop parcurgere
                jmp end_program
            
            bombardat:
                xor eax , eax 
                xor ebx , ebx
                mov eax , dword[index]
                mov ebx , dword[n]
                div bl
                inc ah 
                inc al
                xor ebx , ebx
                xor ecx , ecx 
                mov bl , al
                mov cl , ah
                push dword ecx
                push dword ebx 
                push dword afisare_avion
                call [printf]
                add esp , 4*3
                
                xor eax , eax 
                mov eax , dword[bombardate]
                inc eax 
                mov dword[bombardate] , eax
            
            not_bombardat:
                mov ecx , dword[copie]
                cmp ecx , 0
                ja revenire1
        
        end_program:
        
        xor ecx , ecx 
        mov ecx , len_bombe
        sub ecx , dword[bombardate]
        mov eax , dword[bombardate]
        mov ebx , dword[m]
        
        push dword ecx 
        push dword ebx
        push dword eax 
        push afisare_rezultat
        call [printf]
        add esp , 4*3
        
        push    dword 0      
        call    [exit]       
