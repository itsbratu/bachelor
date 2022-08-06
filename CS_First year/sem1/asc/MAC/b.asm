bits 32

global start        

extern exit , printf        
import exit msvcrt.dll  
import printf msvcrt.dll  
                         

segment data use32 class=data
    mac db "ab:21:33:c2:f2:11" , 0
    len_mac equ ($-mac)
    msg_neg db "Sirul dat nu este o adresa mac ! " , 0
    msg_afr db "Sirul dat este o adresa mac ! " , 0
    puncte dd 0
    contor dd 0
    copie dd 0
    pointer dd 0
    cifre_hexa db "0123456789abcdef:" , 0
    len_hexa equ ($-cifre_hexa)

segment code use32 class=code
    start:
    
        mov ecx , len_mac
        dec ecx
        cmp ecx , 17
        jne not_mac
        
        mov esi , mac
        mov al , byte[esi+0]
        cmp al , ':'
        je not_mac
        
        dec ecx 
        mov al , byte[esi+ecx]
        cmp al , ':'
        je not_mac
       
        
        mov esi , mac 
        mov ecx , len_mac
        dec ecx 
        
        parcurgere_sir:
            lodsb
            cmp al , ":"
            je doua_puncte
            
            xor ebx , ebx
            mov ebx , dword[contor]
            inc ebx
            mov dword[contor] , ebx
            jmp final_curr
            
            doua_puncte:
                mov ebx , dword[puncte]
                inc ebx 
                mov dword[puncte] , ebx
                
                mov ebx , dword[contor]
                cmp ebx , 2
                jne not_mac
                
                xor ebx , ebx 
                mov dword[contor] , ebx
        
            final_curr:
        
        loop parcurgere_sir
        
        mov ecx , dword[puncte]
        cmp ecx , 5
        jne not_mac
        
        mov esi , mac
        mov ecx , len_mac
        dec ecx
        
        parcurgere_x2:
            lodsb 
            mov dword[copie] , ecx
            mov dword[pointer] , esi
            
            mov bl , al
            mov esi , cifre_hexa
            mov ecx , len_hexa
            dec ecx
                parcurgere_hexa:
                    lodsb
                    cmp al , bl 
                    je is_match
                loop parcurgere_hexa
            jmp not_mac
            is_match:
            mov ecx , dword[copie]
            mov esi , dword[pointer]
        
        loop parcurgere_x2
        
        jmp is_mac
        
        not_mac:
            push dword msg_neg
            call [printf]
            add esp , 4
            jmp final
        is_mac:
            push dword msg_afr
            call [printf]
            add esp , 4
        
        final:
        
        push    dword 0      
        call    [exit]       
