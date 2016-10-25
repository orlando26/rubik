'Sólo para excel. Lo que se coloca en public se podrá utilizar en varios subs o en varias funciones.
Public ColocarColor As Range
Public ColorBoton As Variant
Public ws As Worksheet
Public wsA As Worksheet
Public wb As Workbook

'Para programa principal
Public a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z                     As Variant   'Letras de aristas
Public vA, vB, vC, vD, vE, vF, vG, vH, vI, vJ, vK, vL, vM, vN, vO, vP, vQ, vR, vS, vT, vU, vV, vW, vX   As Variant   'Letras de esquinas
Public EsquinasMemo                                                 'Para distinguir si se está en el paso de Esquinas
Public AristasMemo                                                  'Para distinguir si se está en el paso de Aristas

'//////////////////////////////////////////////////////////////////////////////////////////////////////////////
'                                            PROGRAMA PRINCIPAL
'//////////////////////////////////////////////////////////////////////////////////////////////////////////////
Private Sub Solucion_Click()
'***Variables, etc
    Set wsA = Worksheets("Algs Modificados")            'Hoja que contiene todos los algoritmos
    Set ws = Worksheets("Simulación_Aristas")           'Hoja donde se realiza la simulación
    ws.Range("M:O").ClearContents                       'Borra los resultados anteriores escritos en la hoja
    ws.Range("R2").Value = ""                           'Borra los resultados anteriores escritos en la hoja

    Dim pieza                   As Variant              'Guardará la pieza que se está analizando: a, b, c, d...
    Dim pareja1                 As Variant              'Pareja(perteneciente) de PIEZA (para aristas y esquinas)
    Dim pareja2                 As Variant              'Pareja 2 (para esquinas)
    Dim buf1, buf2, buf3        As Variant              'Son los colores del buffer y de sus parejas. 1 y 2 para aristas, 3 para esquinas.
    Dim haciaColor, haciaColor2, haciaColor3 As Variant 'Colores de la pieza analizada y de sus parejas.
    Dim revisados               As New Collection       'Lista de piezas que ya se revisaron
    Dim esquinas                As New Collection       'Lista de letras "memorizadas" para esquinas
    Dim completo                As New Collection       'Lista de "a" a "x".
    Dim posible                                         'Arreglo de letras relacionadas a una cara. Ej a,b,c,d para blanco, etc.
    Dim parejaTemp              As Variant              'Pareja de la pieza hacia donde "podría" ir la pieza que está en el buffer
    Dim haciaColorTemp2         As Variant              'Color de ParejaTemp
    Dim cuantos                 As Integer              'Cantidad de letras en la lista Revisados
    Dim randomNo                As Integer              'Numero random que se usará al iniciar otro ciclo
    Dim buffer                  As Variant              'Pieza buffer de ciclos que no empiezan en a o m
    Dim parejaB                 As Variant              'Pareja de buffer de ciclos que no empiezan en a o m
    
    Dim cc                      As Integer              'Contador xs
    Dim zz                      As Integer              'Contador xs
    
    Dim conteoEsquinas          As Integer              'Se usará para saber cuántas Esquinas se memorizaron
    Dim countA                  As Integer              'Contador para revisar si la arista es par o impar
    Dim countAesPar             As Integer              'Se usará para saber si la posición de la arista en el arreglo memorizado es par o impar
    Dim paridad                 As String               'Se usará para saber si existe paridad o no
    
    Dim aristaNombre            As Range                'Se usará como la dirección donde se colocarán las Esquinas memorizadas.

'Solución de esquinas
        EsquinasMemo = 1                                    'Comienza Memorización de esquinas
        AristasMemo = 0

        '***PARA EXCEL***
        vA = "i6": vB = "g6": vC = "g4": vD = "i4"
        vE = "a7": vF = "c7": vG = "c9": vH = "a9"
        vI = "d7": vJ = "f7": vK = "f9": vL = "d9"
        vM = "g7": vN = "i7": vO = "i9": vP = "g9"
        vQ = "j7": vR = "l7": vS = "l9": vT = "j9"
        vU = "g10": vV = "i10": vW = "i12": vX = "g12"

    '--- MÉTODO DE SOLUCIÓN (MEMORIZACIÓN)
        pieza = vA                    'Siempre se comienza a memorizar el primer ciclo en el buffer (en la pieza A)
        buf1 = "bla"                  'El color del buffer siempre será blanco
        buf2 = "ver"                  'El color de la pareja1 del buffer siempre será verde
        buf3 = "roj"                  'El color de la parej2 del buffer siempre será rojo

        loop1 = 0                     'Sirve para decidir si salir del Do 1(loop1)
        nunca = 0                     'Sirve para "controlar" el loop 1.1

        Do 'loop1
            Do   'loop2
                Do While nunca = 0              'loop 1.1

                    If loop1 = 1 Then
                        Exit Do                  'sale de loop1.1
                    End If

                    haciaColor = Hacia(pieza)                  'Función "Hacia" regresa el color actual de PIEZA
                    pareja1 = Perteneciente(pieza)(0)          'Perteneciente de PIEZA devuelve letra pareja1 de PIEZA
                    pareja2 = Perteneciente(pieza)(1)
                    haciaColor2 = Hacia(pareja1)               'Función "Hacia" regresa el color actual de Pareja
                    haciaColor3 = Hacia(pareja2)
                    revisados.Add pieza                        'Se agregar PIEZA y Pareja a la lista de "Revisados"
                    revisados.Add pareja1
                    revisados.Add pareja2
                
                    If (haciaColor = buf1 And haciaColor2 = buf2 And haciaColor3 = buf3) _
                        Or (haciaColor = buf1 And haciaColor2 = buf3 And haciaColor3 = buf2) _
                        Or (haciaColor = buf2 And haciaColor2 = buf1 And haciaColor3 = buf3) _
                        Or (haciaColor = buf2 And haciaColor2 = buf3 And haciaColor3 = buf1) _
                        Or (haciaColor = buf3 And haciaColor2 = buf1 And haciaColor3 = buf2) _
                        Or (haciaColor = buf3 And haciaColor2 = buf2 And haciaColor3 = buf1) Then 'Si los colores en el buffer SON los colores del buffer
                    
                        rompe = 1
                        Exit Do 'salir del loop 1.1
                        
                    End If
            
            
                    '*******3. COMIENZA CICLO DE "MEMORIZACIÓN"
                    nunca = 1
                Loop 'loop1.1
        
                If rompe = 1 Then
                    rompe = 0
                    Exit Do 'salir de loop2
                End If
                                                                    
                posible = Posibles(haciaColor)                              'Devuelve las piezas donde podría ir la pieza que está en el buffer
                cc = 0                                                      'Para revisar en arreglo "posible""
                loop3 = 0
            
                Do While loop3 = 0 'loop3
        
                    ParejaTemp1 = Perteneciente(posible(cc))(0)             'Pareja temporal es la pareja de la 1era, 2da, 3era o 4ta pieza del arreglo "posible()"
                    ParejaTemp2 = Perteneciente(posible(cc))(1)
                    haciaColorTemp2 = centro(ParejaTemp1)                   'Color de la pareja temporal a donde podría ir la pieza que está en el buffer
                    HaciaColorTemp3 = centro(ParejaTemp2)
                
                    If ((haciaColorTemp2 = haciaColor2 And HaciaColorTemp3 = haciaColor3) = 0 And _
                        (haciaColorTemp2 = haciaColor3 And HaciaColorTemp3 = haciaColor2) = 0) Then            'Si el color de la pareja de PIEZA no es igual al color centro de la pareja de Posible
                            cc = cc + 1                                     'Incrementa el contador en 1 para checar la siguiente pieza en "Posibles()"
                            loop3 = 0       'Para repetir el loop3
                    Else
                            loop3 = 1       'Para salir del loop3
                    End If
                Loop 'loop3                                                 'Regresa a para revisar la siguiente pieza posible
        
                esquinas.Add posible(cc)                                'Agrega la pieza posible a memorización de esquinas
                pieza = posible(cc)                                     'Ahora se revisará a dónde va esta nueva pieza
                
                nunca = 0
                loop1 = 0
        
            Loop 'loop2                                     'Se llega aquí cuando se completa un ciclo
                                                            
            Set completo = Nothing                          'Vacía la lista de letras de esquinas sin revisar
            completo.Add vA, vA                             'Agrega esquina "A" (dirección y nombre) a la lista de esquinas sin revisar
            completo.Add vB, vB
            completo.Add vC, vC                             'La primer letra lleva a la dirección, aquí C=celda g4
            completo.Add vD, vD                             'La segunda letra es la etiqueta de esa dirección, aquí es vD.
            completo.Add vE, vE
            completo.Add vF, vF
            completo.Add vG, vG
            completo.Add vH, vH
            completo.Add vI, vI
            completo.Add vJ, vJ
            completo.Add vK, vK
            completo.Add vL, vL
            completo.Add vM, vM
            completo.Add vN, vN
            completo.Add vO, vO
            completo.Add vP, vP
            completo.Add vQ, vQ
            completo.Add vR, vR
            completo.Add vS, vS
            completo.Add vT, vT
            completo.Add vU, vU
            completo.Add vV, vV
            completo.Add vW, vW
            completo.Add vX, vX

            cuantos = revisados.Count                                       'Cuantos es la cantidad de aristas revisadas
        
            For zz = 1 To cuantos
                On Error Resume Next                                        'Si ocurre error en siguiente linea (si ya se había eliminado la arista),checa la siguiente letra en "revisados"
                completo.Remove revisados(zz)                               'Elimina de la lista Completo las aristas que ya se revisaron, se usará para saber cuantas y cuáles piezas faltan de revisar
            Next zz

            If completo.Count = 0 Then                                      'Si ya no hay piezas por revisar
                Exit Do 'sale de loop1
            End If

            '-----------------   4. COMIENZA SIGUIENTE CICLO DE MEMORIZACIÓN

            Randomize                                                       'Inicializa el generador de números aleatorios de la función Rnd
            randomNo = Int(completo.Count * Rnd) + 1                        'Número random de 1 hasta el tamaño de Completo (aristas que faltan de revisar)
        
            'Cuando se comienza un ciclo nuevo, se selecciona un buffer nuevo, este buffer nuevo sí se tiene que "memorizar", a diferencia de a o m
        
            pieza = completo(randomNo)                                      'Pieza será la pieza número "RandomNo" en el arreglo "Completo" (de las que faltaban de revisar)
            buffer = pieza                                                  'El buffer es esa pieza random seleccionada.
            buf1 = Hacia(buffer)                                            'Color del nuevo buffer
            haciaColor = buf1                                               'El color del nuevo buffer indica hacia dónde irá esa pieza(nuevo buffer).

            ParejaB1 = Perteneciente(buffer)(0)                             'Pareja del nuevo buffer...
            ParejaB2 = Perteneciente(buffer)(1)
            pareja1 = ParejaB1                                              '...será la pareja de la pieza a analizar (buffer nuevo)
            pareja2 = ParejaB2
            buf2 = Hacia(ParejaB1)                                          'Color de la pareja del nuevo buffer...
            buf3 = Hacia(ParejaB2)
            haciaColor2 = buf2                                              '...será el color de la pieza a analizar(buffer nuevo)
            haciaColor3 = buf3
        
            esquinas.Add pieza                                              'Se agrega el nuevo buffer a esquinas memorizadas
            revisados.Add pieza                                             'Se agrega el nuevo buffer y su(s) pareja(s) a piezas revisadas.
            revisados.Add pareja1
            revisados.Add pareja2
                                                                        
            loop1 = 1                                                           'Comienza ciclo (uno nuevo :D, dentro del paso 3)
            nunca = 1
        Loop 'loop1
        

        '-----------------   5. TERMINA MEMORIZACIÓN Y ESCRIBE EN LA HOJA LAS ESQUINAS MEMORIZADAS
        conteoEsquinas = esquinas.Count                              'Número de esquinas memorizadas, contando las repetidas :s
        ConteoEsquinasT = conteoEsquinas                             'Número de esquinas memorizadas, luego se reducirá si hay repetidas, y servirá para saber si hay paridad o no

        zzT = 1                                                      'Servirá para decrementar la posición donde se colocará la esquina memorizada, por si se repetían valores

        For zz = 1 To conteoEsquinas
            Set EsquinaNombre = ws.Range("N" & zzT)                  'Escribe arista por arista hacia abajo en la columna N
            EsquinaTemp2 = ws.Range(esquinas(zz)).Value              'Guarda letra de arista actual
                
            If EsquinaTemp2 = EsquinaTemp1 Then                      'Si es igual a la anterior, era repetida, entonces zzT=zzT-2
                zzT = zzT - 2                                             'De todas formas incrementará en 1 cuando zzT=zzT+1
                ConteoEsquinasT = ConteoEsquinasT - 2                     'Hay una arista repetida, entonces se eliminan las repeticiones (2)
            Else
                EsquinaNombre.Value = ws.Range(esquinas(zz)).Value
                EsquinaTemp1 = ws.Range(esquinas(zz)).Value                'Guarda letra de arista actual, será la anterior cuando vuelva a entrar el For
            End If

            zzT = zzT + 1                                            'Incrementa el lugar donde se colocará la siguiente arista memorizada
        Next zz
        
        If EsquinaTemp2 = EsquinaTemp1 Then
            Set EsquinaNombre = ws.Range("N" & zzT)
            EsquinaNombre.Value = ""
        End If
        
    '--- MÉTODO DE EJECUCIÓN
        If (1 - (ConteoEsquinasT Mod 2)) = 0 Then               'Si conteoEsquinasT es Impar (0 para impar, 1 para par)
            paridad = "ConParidad"                              'En el método, si es impar el conteo, existe "paridad"
        Else
            paridad = "SinParidad"                              'En el método, si el conteo es par, no hay paridad
        End If


        For CountE = 1 To ConteoEsquinasT
            '1 si es par, 0 si es impar
            CountEesPar = 1 - (CountE Mod 2)                                ' Posición de esquina actual es par o impar?

            If ws.Range("N" & CountE).Value = "B" Then                      ' Algoritmos de esquina B
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vBimpar")     '"Abimpar" es el nombre de la celda en hoja wsA="Algs Modificados"
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vBpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "C" Then                 'Arista c
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vCimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vCpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "D" Then                 'Arista d
                        ws.Range("O" & CountE).Value = ""
                    
                ElseIf ws.Range("N" & CountE).Value = "E" Then                 'Arista e
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vEimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vEpar")
                    End If
                        
                ElseIf ws.Range("N" & CountE).Value = "F" Then                 'Arista f
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vFimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vFpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "G" Then                 'Arista g
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vGimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vGpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "H" Then                 'Arista h
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vHimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vHpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "I" Then                 'Arista i
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vIimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vIpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "J" Then                 'Arista j
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vJimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vJpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "K" Then                 'Arista k
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vKimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vKpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "L" Then                 'Arista l
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vLimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vLpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "M" Then                 'Arista m
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vMimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vMpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "N" Then                 'Arista n
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vNimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vNpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "O" Then                 'Arista o
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vOimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vOpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "P" Then                 'Arista p
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vPimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vPpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "Q" Then                 'Arista q
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vQimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vQpar")
                    End If
                
                ElseIf ws.Range("N" & CountE).Value = "R" Then                 'Arista r
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vRimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vRpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "S" Then                 'Arista s
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vSimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vSpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "T" Then                 'Arista t
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vTimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vTpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "U" Then                 'Arista u
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vUimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vUpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "V" Then                 'Arista v
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vVimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vVpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "W" Then                 'Arista w
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vWimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vWpar")
                    End If
                    
                ElseIf ws.Range("N" & CountE).Value = "X" Then                 'Arista x
                    If CountEesPar = 0 Then
                        ws.Range("O" & CountE).Value = wsA.Range("vXimpar")
                        Else
                        ws.Range("O" & CountE).Value = wsA.Range("vXpar")
                    End If
            End If
            
        Next CountE
        
        ws.Range("R2").Formula = "=CONCAT(O:O)"                   'Escribe el algoritmo entero para resolver esquinas en celda R2
        ws.Range("R2").Copy
        ws.Range("R2").PasteSpecial xlPasteValues                 'Lo pega ahí mismo para que aparezca como valores y no como fórmula.
        ws.Range("A1").Select
        
'Solución de aristas
    '--------------------------------------------------------------------------------------------------------------------------------------------------
    '                                       Declaración de variables y otras inicializaciones para ARISTAS
    '-------------------------------------------------------------------------------------------------------------------------------------------------

                                                    'es Variant porque también se puede referir a su ubicación, ej a="h6"
Dim Pareja                  As Variant              'Pareja(perteneciente) de PIEZA
Dim Aristas                 As New Collection       'Lista de PIEZAs (aristas) "memorizadas"
Set wsA = Worksheets("Algs Modificados")            'wsA es la hoja que contiene tooodos los algoritmos
Set ws = Worksheets("Simulación_Aristas")

EsquinasMemo = 0
AristasMemo = 1

'-------------------------------------------------------------------------------------------------------------
'                      Referencias de letras a la hoja "Simulación_aristas"
a = "h6"
b = "g5"
c = "h4"
d = "i5"
e = "b7"
f = "c8"
g = "b9"
h = "a8"
i = "e7"
j = "f8"
k = "e9"
l = "d8"
m = "h7"
n = "i8"
o = "h9"
p = "g8"
q = "k7"
r = "l8"
s = "k9"
t = "j8"
u = "h10"
v = "i11"
w = "h12"
x = "g11"

'------------------------------------------------------------------------------------------------------------------------------------------
'                                              MÉTODO DE SOLUCIÓN (MEMORIZACIÓN)
'------------------------------------------------------------------------------------------------------------------------------------------

'Blanco arriba, verde en frente
    
pieza = a                     'Siempre se comienza a memorizar el primer ciclo en el buffer (en la pieza a)
buf1 = "bla"                  'El color del buffer siempre será blanco
buf2 = "ver"                  'El color de la pareja del buffer siempre será verde
Set revisados = Nothing

    loop1 = 0                                                           'Comienza ciclo (uno nuevo :D, dentro del paso 3)
    nunca = 0

Do  'loop1 esquinas
    Do 'loop 2 esquinas
        Do While nunca = 0              'loop 1.1 esquinas

                    If loop1 = 1 Then
                        Exit Do                  'sale de loop1.1
                    End If
    '-------------------------------------------------------------------------------------------------
    '                                      1. COLORES EN EL BUFFER
          
     haciaColor = Hacia(pieza)        'Función "Hacia" regresa el color actual de PIEZA

    '-------------------------------------------------------------------------------------------------
    '                                        Perteneciente (Pareja)

     Pareja = Perteneciente(pieza)    'Perteneciente de PIEZA devuelve letra pareja de PIEZA.
                                      'Ej: para "a" es "m", para "i" es "b" etc.

    '-------------------------------------------------------------------------------------------------
    '                                        Color de pareja

     haciaColor2 = Hacia(Pareja)      'Función "Hacia" regresa el color actual de Pareja

    '-------------------------------------------------------------------------------------------------
    '                                      2. PIEZAS REVISADAS
    
     revisados.Add pieza              'Se agregar PIEZA y Pareja a la lista de "Revisados"
     revisados.Add Pareja

    If (haciaColor = buf1 And haciaColor2 = buf2) _
        Or (haciaColor = buf2 And haciaColor2 = buf1) Then  'Si los colores en el buffer SON los colores del buffer
    rompe = 1
    Exit Do
    End If


        nunca = 1
        Loop 'loop 1.1 esquinas
        
        
                   If rompe = 1 Then
                    rompe = 0
                    Exit Do 'salir de loop2
                End If
    '-------------------------------------------------------------------------------------------------
    '                                      3. COMIENZA CICLO DE "MEMORIZACIÓN"

    posible = Posibles(haciaColor)                          'La función "Posibles" devuelve las piezas donde podría
                                                            ' ir la pieza que está en el buffer, depende del color de PIEZA
    
    cc = 0                                                  'cc=0 para revisar la primer pieza de Posibles(), el arreglo va de 0-3 (4piezas en la cara)
    loop3 = 0
            
    Do While loop3 = 0 'loop3 esquinas
    
    parejaTemp = Perteneciente(posible(cc))             'Pareja temporal es la pareja de la 1era, 2da, 3era o 4ta pieza del arreglo "Posibles()"
        haciaColorTemp2 = centro(parejaTemp)      'Color de la pareja temporal a donde podría ir la pieza que está en el buffer
        If haciaColorTemp2 <> haciaColor2 Then              'Si el color de la pareja de PIEZA no es igual al color de la pareja de Posible
            cc = cc + 1                                        'Incrementa el contador en 1 para checar la siguiente pieza en "Posibles()"
            loop3 = 0       'Para repetir el loop3
         Else
            loop3 = 1       'Para salir del loop3
        End If
    Loop 'loop3
    
    
    Aristas.Add posible(cc)                                   'Agrega la pieza posible a la lista de Aristas memorizadas.
    pieza = posible(cc)                                       'Ahora se revisará a dónde va esta nueva pieza


    loop1 = 0                                                           'Comienza ciclo (uno nuevo :D, dentro del paso 3)
    nunca = 0

    Loop 'loop2 esquinas
    Set completo = Nothing                                  'Vacía la lista de letras de aristas sin revisar
    completo.Add a, a                                       'Agrega arista "a" (dirección: H6) a la lista de aristas sin revisar, y su nombre = a
    completo.Add b, b
    completo.Add c, c                                       'La primer letra lleva a la dirección, aquí c=celda h4
    completo.Add d, d                                       'La segunda letra es el nombre de esa dirección, aquí es d.
    completo.Add e, e
    completo.Add f, f
    completo.Add g, g
    completo.Add h, h
    completo.Add i, i
    completo.Add j, j
    completo.Add k, k
    completo.Add l, l
    completo.Add m, m
    completo.Add n, n
    completo.Add o, o
    completo.Add p, p
    completo.Add q, q
    completo.Add r, r
    completo.Add s, s
    completo.Add t, t
    completo.Add u, u
    completo.Add v, v
    completo.Add w, w
    completo.Add x, x


    cuantos = revisados.Count                                       'Cuantos es la cantidad de aristas revisadas
    
    For zz = 1 To cuantos
        On Error Resume Next                                        'Si ocurre error en siguiente linea (si ya se había eliminado la arista)...
                                                                 '...checa la siguiente letra en Revisados
        completo.Remove revisados(zz)                               'Elimina de la lista Completo las aristas que ya se revisaron,
                                                                    'Se usará para saber cuantas y cuáles piezas faltan de revisar.
    Next zz

    If completo.Count = 0 Then                                      'Si ya no hay piezas por revisar
        Exit Do 'sale de loop 1 esquinas
    End If

    '-------------------------------------------------------------------------------------------------
    '                                      4. COMIENZA SIGUIENTE CICLO DE MEMORIZACIÓN

    Randomize                                                       'Inicializa el generador de números aleatorios de la función Rnd
    randomNo = Int(completo.Count * Rnd) + 1                        'Número random de 1 hasta el tamaño de Completo (aristas que faltan de revisar)
    
    'Cuando se comienza un ciclo nuevo, se selecciona un buffer nuevo, este buffer nuevo sí se tiene que "memorizar", a diferencia de a o m
    
    pieza = completo(randomNo)                                      'Pieza será la pieza número "RandomNo" en el arreglo "Completo" (de las que faltaban de revisar)
    buffer = pieza                                                  'El buffer es esa pieza random seleccionada.
    buf1 = Hacia(buffer)                                            'Color del nuevo buffer
    haciaColor = buf1                                               'El color del nuevo buffer indica hacia dónde irá esa pieza(nuevo buffer).

    parejaB = Perteneciente(buffer)                                 'Pareja del nuevo buffer..
    Pareja = parejaB                                                '.. será la pareja de la pieza a analizar (buffer nuevo)
    buf2 = Hacia(parejaB)                                           'Color de la pareja del nuevo buffer...
    haciaColor2 = buf2                                              '...será el color de la pieza a analizar(buffer nuevo)

    Aristas.Add pieza                                               'Se agrega el nuevo buffer a aristas memorizadas
    revisados.Add pieza                                             'Se agrega el nuevo buffer y su pareja a piezas revisadas.
    revisados.Add Pareja
    
    loop1 = 1                                                           'Comienza ciclo (uno nuevo :D, dentro del paso 3)
    nunca = 1

Loop 'loop1 esquinas


    '-------------------------------------------------------------------------------------------------
    '                 5. TERMINA MEMORIZACIÓN Y ESCRIBE EN LA HOJA LAS ARISTAS MEMORIZADAS

    ConteoAristas = Aristas.Count                                   'Número de aristas memorizadas, contando las repetidas :s
    ConteoAristasT = ConteoAristas                                  'Número de aristas memorizadas, luego se reducirá si hay repetidas, y servirá
                                                                    'para saber si hay paridad o no
    zzT = 1                                                         'Servirá para decrementar la posición donde se colocará la arista memorizada
                                                                    'Si es que se repetían valores
    For zz = 1 To ConteoAristas
        Set aristaNombre = ws.Range("N" & zzT + ConteoEsquinasT)                     'Escribe arista por arista hacia abajo en la columna N
        AristaTemp2 = ws.Range(Aristas(zz)).Value                    'Guarda letra de arista actual
            
        If AristaTemp2 = AristaTemp1 Then                            'Si es igual a la anterior, zzT=zzT-1
                zzT = zzT - 2                                            'De todas formas incrementará en 1 cuando zzT=zzT+1
                ConteoAristasT = ConteoAristasT - 2                      'Hay una arista repetida, entonces se eliminan las repeticiones (2)
        Else
                aristaNombre.Value = ws.Range(Aristas(zz)).Value         'Si solo se ponia Aristas(zT), escribiría la celda y no la letra
                AristaTemp1 = ws.Range(Aristas(zz)).Value                'Guarda letra de arista actual, será la anterior cuando vuelva a entrar el For
        End If
            
        zzT = zzT + 1                                                    'Incrementa el lugar donde se colocará la siguiente arista memorizada
        
    Next zz
    
    If AristaTemp2 = AristaTemp1 Then
        Set aristaNombre = ws.Range("N" & zzT + ConteoEsquinasT)
        aristaNombre.Value = ""
    End If
    
'--------------------------------------------------------------------------------------------------------------------------------------------
'                                              MÉTODO DE EJECUCIÓN
'-------------------------------------------------------------------------------------------------------------------------------------------

    'ws.Range("M1").Value = ConteoAristasT                'Escribe en M1 la cantidad de aristas "memorizadas"
    
    If (1 - (ConteoAristasT Mod 2)) = 0 Then             'Si ConteoAristasT es Impar o par (0 para impar, 1 para par)
        paridad = "ConParidad"                              'En el método,  es impar el consiteo, existe "paridad"
        Else
        paridad = "SinParidad"                              'En el método, si el conteo es par, no hay paridad
    End If

'aqui cambie
For countA = 1 To ConteoAristasT

    '1 si es par, 0 si es impar
    countAesPar = 1 - (countA Mod 2)                                'Posición de arista actual es par o impar?

    If ws.Range("N" & countA + ConteoEsquinasT).Value = "b" Then                      ' Algoritmos de Arista b
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Abimpar")   '"Abimpar" es el nombre de la celda en hoja wsA="Algs Modificados"
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Abpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "c" Then                 'Arista c
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Acimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Acpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "d" Then                 'Arista d
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Adimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Adpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "e" Then                 'Arista e
            ws.Range("O" & countA + ConteoEsquinasT).Value = ""
            
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "f" Then                 'Arista f
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Afimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Afpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "g" Then                 'Arista g
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Agimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Agpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "h" Then                 'Arista h
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Ahimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Ahpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "i" Then                 'Arista i
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Aiimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Aipar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "j" Then                 'Arista j
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Ajimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Ajpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "k" Then                 'Arista k
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Akimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Akpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "l" Then                 'Arista l
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Alimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Alpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "m" Then                 'Arista m
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Amimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Ampar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "n" Then                 'Arista n
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Animpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Anpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "o" Then                 'Arista o
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Aoimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Aopar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "p" Then                 'Arista p
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Apimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Appar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "q" Then                 'Arista q
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Aqimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Aqpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "r" Then                 'Arista r
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Arimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Arpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "s" Then                 'Arista s
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Asimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Aspar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "t" Then                 'Arista t
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Atimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Atpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "u" Then                 'Arista u
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Auimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Aupar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "v" Then                 'Arista v
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Avimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Avpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "w" Then                 'Arista w
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Awimpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Awpar")
        End If
        
     ElseIf ws.Range("N" & countA + ConteoEsquinasT).Value = "x" Then                 'Arista x
        If countAesPar = 0 Then
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Aximpar")
        Else
            ws.Range("O" & countA + ConteoEsquinasT).Value = wsA.Range("Axpar")
        End If
     End If
    
     'If CountA = ConteoAristasT And Paridad = "ConParidad" Then       'Si ya se colocaron todos los algoritmos de aristas "memorizadas"
     
     If (countA = ConteoAristasT) And (paridad = "ConParidad") Then    'Si ya se colocaron todos los algoritmos de aristas "memorizadas"
                                                                        'y si hay paridad
        ws.Range("O" & countA + ConteoEsquinasT + 1).Value = wsA.Range("Paridad")   'Colocar abajo el algoritmo de paridad
        ws.Range("N" & countA + ConteoEsquinasT + 1).Value = " (Paridad) "           'Etiqueda " (Paridad) "
     Else
     End If

Next countA
    
    ws.Range("R2").Formula = "=CONCAT(O:O)"                   'Escribe el algoritmo entero para resolver el cubo en celda R2
    ws.Range("R2").Copy
    ws.Range("R2").PasteSpecial xlPasteValues                 'Lo pega ahí mismo para que aparezca como valores y no como fórmula.
    ws.Range("A1").Select

    '-------------------------------------------------------------------------------------------------
    '                    Conteo de giros necesarios para resolver el cubo con éste método

Dim Algoritmo As String
Dim GirosEnAlgoritmo As Long
Dim GirosRepetidos As Long


    Algoritmo = Range("R2").Value
    GirosEnAlgoritmo = Len(Algoritmo) - Len(Application.WorksheetFunction.Substitute(Algoritmo, " ", ""))
    GirosRepetidos = Len(Algoritmo) - Len(Application.WorksheetFunction.Substitute(Algoritmo, "2", ""))
    GirosTotales = GirosRepetidos + GirosEnAlgoritmo
    Range("A11").Value = GirosTotales
    Range("B11").Value = "Giros de 90°"

    Range("A12").Value = GirosTotales / 3 / 60
    Range("B12").Value = "Minutos, si se hacen 3 giros por segundo"

End Sub

Function Hacia(ByRef variable As Variant)                          '-------------------------------------Función 1/4
'----------------------------------------------------------------
'              Devuelve el color de buffer, pieza o pareja
'----------------------------------------------------------------
    If Range(variable).Interior.Color = RGB(255, 255, 255) Then
        Hacia = "bla"
    ElseIf Range(variable).Interior.Color = RGB(255, 255, 0) Then
        Hacia = "ama"
    ElseIf Range(variable).Interior.Color = RGB(0, 112, 192) Then
        Hacia = "azu"
    ElseIf Range(variable).Interior.Color = RGB(0, 176, 80) Then
        Hacia = "ver"
    ElseIf Range(variable).Interior.Color = RGB(255, 0, 0) Then
        Hacia = "roj"
    ElseIf Range(variable).Interior.Color = RGB(255, 152, 1) Then
        Hacia = "nar"
    End If
End Function

Function Posibles(ByRef variable As Variant)                       '-------------------------------------Función 2/4
'----------------------------------------------------------------
'                Devuelve las letras de un color
'----------------------------------------------------------------
  If AristasMemo = 1 Then
    Select Case variable
            Case "bla": Posibles = Array(a, b, c, d)
            Case "azu": Posibles = Array(e, f, g, h)
            Case "nar": Posibles = Array(i, j, k, l)
            Case "ver": Posibles = Array(m, n, o, p)
            Case "roj": Posibles = Array(q, r, s, t)
            Case "ama": Posibles = Array(u, v, w, x)
    End Select
  Else
    Select Case variable
            Case "bla": Posibles = Array(vA, vB, vC, vD)
            Case "azu": Posibles = Array(vE, vF, vG, vH)
            Case "nar": Posibles = Array(vI, vJ, vK, vL)
            Case "ver": Posibles = Array(vM, vN, vO, vP)
            Case "roj": Posibles = Array(vQ, vR, vS, vT)
            Case "ama": Posibles = Array(vU, vV, vW, vX)
    End Select
  End If
End Function

Function centro(ByRef variable As Variant)                         '-------------------------------------Función 3/4
'----------------------------------------------------------------
'        Devuelve el color de centro de una Pieza (de una letra)
'----------------------------------------------------------------
   Select Case variable
        Case a, b, c, d: centro = "bla"
        Case e, f, g, h: centro = "azu"
        Case i, j, k, l: centro = "nar"
        Case m, n, o, p: centro = "ver"
        Case q, r, s, t: centro = "roj"
        Case u, v, w, x: centro = "ama"
    
        Case vA, vB, vC, vD: centro = "bla"
        Case vE, vF, vG, vH: centro = "azu"
        Case vI, vJ, vK, vL: centro = "nar"
        Case vM, vN, vO, vP: centro = "ver"
        Case vQ, vR, vS, vT: centro = "roj"
        Case vU, vV, vW, vX: centro = "ama"
    End Select
End Function

Function Perteneciente(ByRef variable As Variant)                  '-------------------------------------Función 4/4
'----------------------------------------------------------------
'                Pertenecientes (parejas)
'----------------------------------------------------------------
        Select Case variable
            Case a: Perteneciente = m
            Case b: Perteneciente = i
            Case c: Perteneciente = e
            Case d: Perteneciente = q
            Case e: Perteneciente = c
            Case f: Perteneciente = l
            Case g: Perteneciente = w
            Case h: Perteneciente = r
            Case i: Perteneciente = b
            Case j: Perteneciente = p
            Case k: Perteneciente = x
            Case l: Perteneciente = f
            Case m: Perteneciente = a
            Case n: Perteneciente = t
            Case o: Perteneciente = u
            Case p: Perteneciente = j
            Case q: Perteneciente = d
            Case r: Perteneciente = h
            Case s: Perteneciente = v
            Case t: Perteneciente = n
            Case u: Perteneciente = o
            Case v: Perteneciente = s
            Case w: Perteneciente = g
            Case x: Perteneciente = k

            Case vA: Perteneciente = Array(vN, vQ)
            Case vB: Perteneciente = Array(vJ, vM)
            Case vC: Perteneciente = Array(vF, vI)
            Case vD: Perteneciente = Array(vR, vE)
            Case vE: Perteneciente = Array(vR, vD)
            Case vF: Perteneciente = Array(vC, vI)
            Case vG: Perteneciente = Array(vL, vX)
            Case vH: Perteneciente = Array(vW, vS)
            Case vI: Perteneciente = Array(vF, vC)
            Case vJ: Perteneciente = Array(vB, vM)
            Case vK: Perteneciente = Array(vP, vU)
            Case vL: Perteneciente = Array(vX, vG)
            Case vM: Perteneciente = Array(vJ, vB)
            Case vN: Perteneciente = Array(vA, vQ)
            Case vO: Perteneciente = Array(vT, vV)
            Case vP: Perteneciente = Array(vU, vK)
            Case vQ: Perteneciente = Array(vN, vA)
            Case vR: Perteneciente = Array(vD, vE)
            Case vS: Perteneciente = Array(vH, vW)
            Case vT: Perteneciente = Array(vV, vO)
            Case vU: Perteneciente = Array(vK, vP)
            Case vV: Perteneciente = Array(vO, vT)
            Case vW: Perteneciente = Array(vS, vH)
            Case vX: Perteneciente = Array(vG, vL)
        End Select
End Function


Private Sub Worksheet_SelectionChange(ByVal Target As Range)       'Para excel, colocar estado inicial
    If Selection.Count = 1 Then
        If Not Intersect(Target, Range("A4:L12")) Is Nothing Then
            ActiveCell.Interior.Color = ColorBoton                      'Coloca el color del boton antes presionado en la celda activa (seleccionada)
            
            Range("A4:F6").Interior.Color = RGB(255, 255, 255)          'No deja colocar color afuera del cubo
            Range("J4:L6").Interior.Color = RGB(255, 255, 255)          'No deja colocar color afuera del cubo
            Range("A10:F12").Interior.Color = RGB(255, 255, 255)        'No deja colocar color afuera del cubo
            Range("J10:L12").Interior.Color = RGB(255, 255, 255)        'No deja colocar color afuera del cubo
            
            Range("H5").Interior.Color = RGB(255, 255, 255)             'Mantiene el color del centro
            Range("B8").Interior.Color = RGB(0, 112, 192)               'Mantiene el color del centro
            Range("E8").Interior.Color = RGB(255, 152, 1)               'Mantiene el color del centro
            Range("H8").Interior.Color = RGB(0, 176, 80)                'Mantiene el color del centro
            Range("H11").Interior.Color = RGB(255, 255, 0)              'Mantiene el color del centro
            Range("k8").Interior.Color = RGB(255, 0, 0)                 'Mantiene el color del centro
        End If
    End If
End Sub

Private Sub BotonLimpiar_Click()        'Para excel

    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    
    ColorInicial = RGB(255, 255, 255)                             'Blanco
    ws.Range("M:O").ClearContents
    ws.Range("R2").Value = ""
    
    Range("A4:L12").Interior.Color = ColorInicial                 'Limpia: pone color blanco
    Range("H5").Interior.Color = RGB(255, 255, 255)               'Colores de los centros
    Range("B8").Interior.Color = RGB(0, 112, 192)
    Range("E8").Interior.Color = RGB(255, 152, 1)
    Range("H8").Interior.Color = RGB(0, 176, 80)
    Range("H11").Interior.Color = RGB(255, 255, 0)
    Range("k8").Interior.Color = RGB(255, 0, 0)
    
End Sub

Private Sub Resolver_Click()            'Para excel
    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Range("G4:I6").Interior.Color = RGB(255, 255, 255)               'Colores de los centros
    Range("A7:C9").Interior.Color = RGB(0, 112, 192)
    Range("D7:F9").Interior.Color = RGB(255, 152, 1)
    Range("G7:I9").Interior.Color = RGB(0, 176, 80)
    Range("J7:L9").Interior.Color = RGB(255, 0, 0)
    Range("G10:I12").Interior.Color = RGB(255, 255, 0)
End Sub

Private Sub BotonBlanco_Click()
    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    ColorBoton = RGB(255, 255, 255)
    ColocarColor.Value = "Blanco"
    ws.Range("G2:I2").Interior.Color = ColorBoton
End Sub

Private Sub BotonAzul_Click()
    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    ColorBoton = RGB(0, 112, 192)
    ColocarColor.Value = "Azul"
    Range("G2:I2").Interior.Color = ColorBoton
End Sub

Private Sub BotonNaranja_Click()
    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    ColorBoton = RGB(255, 152, 1)
    ColocarColor.Value = "Naranja"
    Range("G2:I2").Interior.Color = ColorBoton
End Sub

Private Sub BotonVerde_Click()
    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    ColorBoton = RGB(0, 176, 80)
    ColocarColor.Value = "Verde"
    Range("G2:I2").Interior.Color = ColorBoton
End Sub

Private Sub BotonRojo_Click()
    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    ColorBoton = RGB(255, 0, 0)
    ColocarColor.Value = "Rojo"
    Range("G2:I2").Interior.Color = ColorBoton
End Sub

Private Sub BotonAmarillo_Click()
    Set ws = ActiveWorkbook.Sheets("Simulación_Aristas")
    Set ColocarColor = ws.Range("H2")
    ColorBoton = RGB(255, 255, 0)
    ColocarColor.Value = "Amarillo"
    Range("G2:I2").Interior.Color = ColorBoton
End Sub