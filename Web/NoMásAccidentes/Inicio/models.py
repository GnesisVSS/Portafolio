from django.db import models


class AdminInterfaceTheme(models.Model):
    name = models.CharField(unique=True, max_length=50, blank=True, null=True)
    active = models.BooleanField()
    title = models.CharField(max_length=50, blank=True, null=True)
    title_visible = models.BooleanField()
    logo = models.CharField(max_length=100, blank=True, null=True)
    logo_visible = models.BooleanField()
    css_header_background_color = models.CharField(max_length=10, blank=True, null=True)
    title_color = models.CharField(max_length=10, blank=True, null=True)
    css_header_text_color = models.CharField(max_length=10, blank=True, null=True)
    css_header_link_color = models.CharField(max_length=10, blank=True, null=True)
    css_header_link_hover_color = models.CharField(max_length=10, blank=True, null=True)
    css_module_background_color = models.CharField(max_length=10, blank=True, null=True)
    css_module_text_color = models.CharField(max_length=10, blank=True, null=True)
    css_module_link_color = models.CharField(max_length=10, blank=True, null=True)
    css_module_link_hover_color = models.CharField(max_length=10, blank=True, null=True)
    css_module_rounded_corners = models.BooleanField()
    css_generic_link_color = models.CharField(max_length=10, blank=True, null=True)
    css_generic_link_hover_color = models.CharField(max_length=10, blank=True, null=True)
    css_save_button_background5185 = models.CharField(max_length=10, blank=True, null=True)
    css_save_button_backgroundd677 = models.CharField(max_length=10, blank=True, null=True)
    css_save_button_text_color = models.CharField(max_length=10, blank=True, null=True)
    css_delete_button_backgroucea0 = models.CharField(max_length=10, blank=True, null=True)
    css_delete_button_backgrou6352 = models.CharField(max_length=10, blank=True, null=True)
    css_delete_button_text_color = models.CharField(max_length=10, blank=True, null=True)
    list_filter_dropdown = models.BooleanField()
    related_modal_active = models.BooleanField()
    related_modal_background_color = models.CharField(max_length=10, blank=True, null=True)
    related_modal_rounded_corners = models.BooleanField()
    logo_color = models.CharField(max_length=10, blank=True, null=True)
    recent_actions_visible = models.BooleanField()
    favicon = models.CharField(max_length=100, blank=True, null=True)
    related_modal_background_o7c6e = models.CharField(max_length=5, blank=True, null=True)
    env_name = models.CharField(max_length=50, blank=True, null=True)
    env_visible_in_header = models.BooleanField(blank=True, null=True)
    env_color = models.CharField(max_length=10, blank=True, null=True)
    env_visible_in_favicon = models.BooleanField()
    related_modal_close_button8203 = models.BooleanField()
    language_chooser_active = models.BooleanField()
    language_chooser_display = models.CharField(max_length=10, blank=True, null=True)
    list_filter_sticky = models.BooleanField()
    form_pagination_sticky = models.BooleanField()
    form_submit_sticky = models.BooleanField()
    css_module_background_selec21b = models.CharField(max_length=10, blank=True, null=True)
    css_module_link_selected_color = models.CharField(max_length=10, blank=True, null=True)
    logo_max_height = models.IntegerField()
    logo_max_width = models.IntegerField()
    foldable_apps = models.BooleanField()

    class Meta:
        managed = False
        db_table = 'admin_interface_theme'


class Asesoria(models.Model):
    idasesoria = models.IntegerField(primary_key=True)
    fechaasesoria = models.DateField()
    cantaccidentes = models.IntegerField()
    tasaaccidentes = models.FloatField()
    rutemp = models.ForeignKey('Empresa', models.DO_NOTHING, db_column='rutemp')
    valorasesoria = models.IntegerField()
    runprf = models.ForeignKey('Profesional', models.DO_NOTHING, db_column='runprf')

    class Meta:
        managed = False
        db_table = 'asesoria'


class AuthGroup(models.Model):
    name = models.CharField(unique=True, max_length=150, blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'auth_group'


class AuthGroupPermissions(models.Model):
    group = models.ForeignKey(AuthGroup, models.DO_NOTHING)
    permission = models.ForeignKey('AuthPermission', models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_group_permissions'
        unique_together = (('group', 'permission'),)


class AuthPermission(models.Model):
    name = models.CharField(max_length=255, blank=True, null=True)
    content_type = models.ForeignKey('DjangoContentType', models.DO_NOTHING)
    codename = models.CharField(max_length=100, blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'auth_permission'
        unique_together = (('content_type', 'codename'),)


class AuthUser(models.Model):
    password = models.CharField(max_length=128, blank=True, null=True)
    last_login = models.DateTimeField(blank=True, null=True)
    is_superuser = models.BooleanField()
    username = models.CharField(unique=True, max_length=150, blank=True, null=True)
    first_name = models.CharField(max_length=150, blank=True, null=True)
    last_name = models.CharField(max_length=150, blank=True, null=True)
    email = models.CharField(max_length=254, blank=True, null=True)
    is_staff = models.BooleanField()
    is_active = models.BooleanField()
    date_joined = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'auth_user'


class AuthUserGroups(models.Model):
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)
    group = models.ForeignKey(AuthGroup, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_user_groups'
        unique_together = (('user', 'group'),)


class AuthUserUserPermissions(models.Model):
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)
    permission = models.ForeignKey(AuthPermission, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_user_user_permissions'
        unique_together = (('user', 'permission'),)


class Capacitaciones(models.Model):
    idcapacitacion = models.BigIntegerField(primary_key=True)
    fechacapacitacion = models.CharField(max_length=100)
    horacapacitacion = models.CharField(max_length=100)
    cantasistentes = models.BigIntegerField()
    estado = models.CharField(max_length=100)
    rutemp = models.ForeignKey('Empresa', models.DO_NOTHING, db_column='rutemp')
    runprf = models.ForeignKey('Profesional', models.DO_NOTHING, db_column='runprf')

    class Meta:
        managed = False
        db_table = 'capacitaciones'


class Comuna(models.Model):
    idcomuna = models.IntegerField(primary_key=True)
    nombrecomuna = models.CharField(max_length=100)
    idregion = models.ForeignKey('Region', models.DO_NOTHING, db_column='idregion')

    class Meta:
        managed = False
        db_table = 'comuna'


class Contrato(models.Model):
    idcontrato = models.BooleanField(primary_key=True)
    desccontrato = models.CharField(max_length=10)
    fechainiciocontrato = models.CharField(max_length=10)
    rutemp = models.ForeignKey('Empresa', models.DO_NOTHING, db_column='rutemp')

    class Meta:
        managed = False
        db_table = 'contrato'


class DjangoAdminLog(models.Model):
    action_time = models.DateTimeField()
    object_id = models.TextField(blank=True, null=True)
    object_repr = models.CharField(max_length=200, blank=True, null=True)
    action_flag = models.IntegerField()
    change_message = models.TextField(blank=True, null=True)
    content_type = models.ForeignKey('DjangoContentType', models.DO_NOTHING, blank=True, null=True)
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'django_admin_log'


class DjangoContentType(models.Model):
    app_label = models.CharField(max_length=100, blank=True, null=True)
    model = models.CharField(max_length=100, blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'django_content_type'
        unique_together = (('app_label', 'model'),)


class DjangoMigrations(models.Model):
    app = models.CharField(max_length=255, blank=True, null=True)
    name = models.CharField(max_length=255, blank=True, null=True)
    applied = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'django_migrations'


class DjangoSession(models.Model):
    session_key = models.CharField(primary_key=True, max_length=40)
    session_data = models.TextField(blank=True, null=True)
    expire_date = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'django_session'


class Empresa(models.Model):
    rutemp = models.CharField(primary_key=True, max_length=10)
    nombreemp = models.CharField(max_length=15)
    direccionemp = models.CharField(max_length=100)
    telefonoemp = models.BigIntegerField()
    correoemp = models.CharField(max_length=100)
    idcomuna = models.ForeignKey(Comuna, models.DO_NOTHING, db_column='idcomuna')
    rubroempresa = models.CharField(max_length=100, blank=True, null=True)
    digitoveriemp = models.FloatField()
    rutrepresent = models.ForeignKey('Representante', models.DO_NOTHING, db_column='rutrepresent')

    class Meta:
        managed = False
        db_table = 'empresa'


class Genero(models.Model):
    idsexo = models.IntegerField(primary_key=True)
    descsexo = models.CharField(max_length=10)

    class Meta:
        managed = False
        db_table = 'genero'


class Jornada(models.Model):
    idjornada = models.IntegerField(primary_key=True)
    descjornada = models.CharField(max_length=10)
    idcontrato = models.ForeignKey(Contrato, models.DO_NOTHING, db_column='idcontrato')

    class Meta:
        managed = False
        db_table = 'jornada'


class Pagoplan(models.Model):
    idpago = models.IntegerField(primary_key=True)
    fechapago = models.CharField(max_length=100)
    estadopago = models.CharField(max_length=100)
    montopago = models.IntegerField()
    idplan = models.ForeignKey('Plan', models.DO_NOTHING, db_column='idplan')
    idcontrato = models.ForeignKey(Contrato, models.DO_NOTHING, db_column='idcontrato')

    class Meta:
        managed = False
        db_table = 'pagoplan'


class Perfil(models.Model):
    idperfil = models.BigIntegerField(primary_key=True)
    runprf = models.ForeignKey('Profesional', models.DO_NOTHING, db_column='runprf')

    class Meta:
        managed = False
        db_table = 'perfil'


class Plan(models.Model):
    idplan = models.IntegerField(primary_key=True)
    nombreplan = models.CharField(max_length=25)
    cantvisitas = models.IntegerField()
    cantasesorias = models.IntegerField()
    cantcapacitacion = models.IntegerField()
    valorplan = models.IntegerField()
    idasesoria = models.ForeignKey(Asesoria, models.DO_NOTHING, db_column='idasesoria')
    idtipoplan = models.ForeignKey('Tipoplan', models.DO_NOTHING, db_column='idtipoplan')

    class Meta:
        managed = False
        db_table = 'plan'


class Profesion(models.Model):
    idprofesion = models.IntegerField(primary_key=True)
    pr_descripcion = models.CharField(max_length=12)
    pr_sueldo = models.IntegerField()
    pr_especialidad = models.CharField(max_length=10, blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'profesion'


class Profesional(models.Model):
    runprf = models.CharField(primary_key=True, max_length=10)
    pnombreprf = models.CharField(max_length=15)
    apellidopatprf = models.CharField(max_length=20)
    apellidomatprf = models.CharField(max_length=20)
    edadprf = models.IntegerField()
    correoprf = models.CharField(max_length=100)
    telefonoprf = models.CharField(max_length=13)
    fechanacprf = models.CharField(max_length=100)
    direccionprf = models.CharField(max_length=50)
    experienciaprf = models.IntegerField()
    fechacontrataprf = models.CharField(max_length=100)
    idprofesion = models.ForeignKey(Profesion, models.DO_NOTHING, db_column='idprofesion')
    paisnacimientoprf = models.CharField(max_length=10)
    digitoverificadorprf = models.FloatField()
    idjornada = models.ForeignKey(Jornada, models.DO_NOTHING, db_column='idjornada')
    idsexo = models.ForeignKey(Genero, models.DO_NOTHING, db_column='idsexo')
    contrasenaprf = models.CharField(max_length=100)

    class Meta:
        managed = False
        db_table = 'profesional'


class Region(models.Model):
    idregion = models.IntegerField(primary_key=True)
    nombreregion = models.CharField(max_length=100)

    class Meta:
        managed = False
        db_table = 'region'


class Registro(models.Model):
    idregistro = models.CharField(primary_key=True, max_length=100)
    item1 = models.CharField(max_length=1)
    item2 = models.CharField(max_length=1)
    item3 = models.CharField(max_length=1)
    comentarioitem1 = models.CharField(max_length=100)
    comentarioitem2 = models.CharField(max_length=100)
    comentarioitem3 = models.CharField(max_length=100)
    itemextra1 = models.CharField(max_length=1, blank=True, null=True)
    itemextra2 = models.CharField(max_length=1, blank=True, null=True)
    itemextra3 = models.CharField(max_length=1, blank=True, null=True)
    comentarioitemextra1 = models.CharField(max_length=100, blank=True, null=True)
    comentarioitemextra2 = models.CharField(max_length=100, blank=True, null=True)
    comentarioitemextra3 = models.CharField(max_length=100, blank=True, null=True)
    idvisita = models.ForeignKey('Visitas', models.DO_NOTHING, db_column='idvisita')

    class Meta:
        managed = False
        db_table = 'registro'


class Representante(models.Model):
    rutrepresent = models.FloatField(primary_key=True)
    digitoverirepresent = models.FloatField()
    nombrerepre = models.CharField(max_length=20)
    apellidorepre = models.CharField(max_length=20)
    cargorepre = models.CharField(max_length=50)
    numeroreprese = models.CharField(max_length=20)
    idsexo = models.ForeignKey(Genero, models.DO_NOTHING, db_column='idsexo')

    class Meta:
        managed = False
        db_table = 'representante'


class Tipocontrato(models.Model):
    idtipocontrato = models.IntegerField(primary_key=True)
    desctipocontrato = models.CharField(max_length=15)
    idcontrato = models.ForeignKey(Contrato, models.DO_NOTHING, db_column='idcontrato')

    class Meta:
        managed = False
        db_table = 'tipocontrato'


class Tipoplan(models.Model):
    idtipoplan = models.CharField(primary_key=True, max_length=100)
    descripcionplan = models.CharField(max_length=100)
    valorplan = models.BigIntegerField()
    cantvisitas = models.IntegerField()
    cantasesorias = models.IntegerField()
    cantcapacitacion = models.IntegerField()

    class Meta:
        managed = False
        db_table = 'tipoplan'


class Visitas(models.Model):
    idvisita = models.BigIntegerField(primary_key=True)
    fechavisita = models.CharField(max_length=100)
    tipovisitas = models.CharField(max_length=100)
    estado = models.CharField(max_length=100)
    rutemp = models.ForeignKey(Empresa, models.DO_NOTHING, db_column='rutemp')
    runprf = models.ForeignKey(Profesional, models.DO_NOTHING, db_column='runprf')

    class Meta:
        managed = False
        db_table = 'visitas'
