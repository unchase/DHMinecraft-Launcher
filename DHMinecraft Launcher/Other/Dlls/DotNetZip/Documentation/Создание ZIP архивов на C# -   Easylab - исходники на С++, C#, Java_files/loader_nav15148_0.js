var navMap = {'<void>':['al_index.php',['index.css','index.js']],'<other>':['al_profile.php',['profile.css','page.css','profile.js','page.js']],'public\\d+($|/)':['al_public.php',['public.css','page.css','public.js','page.js']],'event\\d+($|/)':['al_events.php',['groups.css','page.css','groups.js','page.js']],'club\\d+($|/)':['al_groups.php',['groups.css','page.css','groups.js','page.js']],'publics\\d+($|/)':['al_public.php',['public.css','page.css','public.js','page.js']],'groups(\\d+)?$':['al_groups.php',['groups.css','groups_list.js','indexer.js']],'events$':['al_events.php',['events.css','page.css','events.js','page.js']],'changemail$':['register.php',['reg.css']],'mail($|/)':['al_mail.php',['mail.css','mail.js']],'write\\d*($|/)':['al_mail.php',['mail.css','mail.js']],'im($|/)':['al_im.php',['im.js','im.css','emoji.js','notifier.css']],'audio-?\\d+_\\d+$':['al_audio.php',['audio.css','audio.js']],'audios(-?\\d+)?$':['al_audio.php',['audio.css','audio.js']],'audio($|/)':['al_audio.php',['audio.css','audio.js']],'apps_check($|/)':['al_apps_check.php',['apps.css','apps.js']],'apps($|/)':['al_apps.php',['apps.css','apps.js']],'editapp($|/)':['al_apps_edit.php',['apps.css','apps.js']],'regstep\\d$':['register.php',['reg.js','reg.css','ui_controls.js','ui_controls.css','selects.js']],'video(-?\\d+_\\d+)?$':['al_video.php',['video.js','video.css','videoview.js','videoview.css','indexer.js']],'videos(-?\\d+)?$':['al_video.php',['video.js','video.css','indexer.js']],'feed$':['al_feed.php',['page.css','page.js','feed.css','feed.js']],'friends$':['al_friends.php',['friends.js','friends.css','privacy.css']],'friendsphotos$':['al_photos.php',['friendsphotos.js','photoview.js','friendsphotos.css','photoview.css']],'wall-?\\d+(_\\d+)?$':['al_wall.php',['page.js','page.css','wall.js','wall.css']],'tag\\d+$':['al_photos.php',['photos.js','photoview.js','photos.css','photoview.css']],'albums(-?\\d+)?$':['al_photos.php',['photos.js','photos.css']],'photos(-?\\d+)?$':['al_photos.php',['photos.js','photos.css']],'album-?\\d+_\\d+$':['al_photos.php',['photos.js','photos.css']],'photo-?\\d+_\\d+$':['al_photos.php',['photos.js','photos.css','photoview.js','photoview.css']],'search$':['al_search.php',['search.css','search.js']],'people($|/)':['al_search.php',['search.css','search.js']],'communities$':['al_search.php',['search.css','search.js']],'brands$':['al_search.php',['search.css','search.js']],'invite$':['invite.php',['invite.css','invite.js','ui_controls.css','ui_controls.js']],'join$':['join.php',['join.css','join.js']],'settings$':['al_settings.php',['settings.js','settings.css']],'edit$':['al_profileEdit.php',['profile_edit.js','profile_edit.css']],'blog$':['blog.php',['blog.css']],'fave$':['al_fave.php',['fave.js','fave.css','page.css','wall.css','qsorter.js','indexer.js']],'topic$':['al_board.php',['board.css']],'board\\d+$':['al_board.php',['board.css','board.js']],'topic-?\\d+_\\d+$':['al_board.php',['board.css','board.js']],'stats($|/)':['al_stats.php',['stats.css']],'ru/(.*)?$':['al_pages.php',['pages.css','pages.js','wk.css','wk.js']],'pages($|/)':['al_pages.php',['pages.css','pages.js','wk.css','wk.js']],'page-?\\d+_\\d+$':['al_pages.php',['pages.css','pages.js','wk.css','wk.js']],'restore($|/)':['al_restore.php',['restore.js','restore.css']],'recover($|/)':['recover.php',['recover.js','recover.css']],'gifts\\d*$':['al_gifts.php',['gifts.js','gifts.css']],'docs($|/)':['docs.php',['docs.css','docs.js','indexer.js']],'doc-?\\d+_\\d+$':['docs.php',['docs.css','docs.js','indexer.js']],'docs-?\\d+$':['docs.php',['docs.css','docs.js','indexer.js']],'login($|/)':['al_login.php',['login.css']],'tasks($|/)':['tasks.php',['tasks.css','tasks.js']],'abuse($|/)':['abuse.php',['abuse.css','abuse.js']],'support($|/)':['al_tickets.php',['tickets.css','tickets.js']],'helpdesk($|/)':['al_helpdesk.php',['tickets.css','tickets.js']],'offersdesk($|/)':['offers.php',['offers.css','offers.js']],'payments($|/)':['al_payments.php',['payments.css']],'faq($|/)':['al_faq.php',['faq.css','faq.js']],'tlmd($|/)':['al_talmud.php',['faq.js','faq.css','tickets.css','tickets.js']],'sms_office($|/)':['sms_office.php',['sms_office.css','sms_office.js']],'dev($|/)':['dev.php',['dev.css','dev.js']],'developers($|/)':['al_developers.php',['developers.css']],'help($|/)':['al_help.php',['help.css','help.js']],'claims($|/)':['al_claims.php',['claims.css','claims.js']],'ads$':['ads.php',['ads.css','ads.js']],'adbonus$':['ads.php',['ads.css','ads.js']],'adsbonus$':['ads.php',['ads.css','ads.js']],'adregister$':['ads.php',['ads.css','ads.js']],'adsedit$':['ads_edit.php',['ads.css','ads.js','ads_edit.css','ads_edit.js']],'adscreate$':['ads_edit.php',['ads.css','ads.js','ads_edit.css','ads_edit.js']],'adsmoder$':['ads_moder.php',['ads.css','ads.js','ads_moder.css','ads_moder.js']],'adsweb$':['ads_web.php',['ads.css','ads.js','ads_web.css','ads_web.js']],'exchange$':['ads_posts.php',['ads.css','ads.js','exchange.css','exchange.js']],'offers$':['ads_offers.php',['ads.css','ads.js','ads_offers.css','ads_offers.js']],'offersmoder$':['ads_offers_moder.php',['ads.css','ads.js','ads_offers_moder.css','ads_offers_moder.js']],'test$':['al_help.php',['help.css','help.js']],'agenttest$':['al_help.php',['help.css','help.js']],'grouptest$':['al_help.php',['help.css','help.js']],'dmca$':['al_tickets.php',['tickets.css','tickets.js']],'terms$':['al_help.php',['help.css','help.js']],'privacy$':['al_help.php',['help.css','help.js']],'editdb$':['editdb.php',['editdb.css','editdb.js']],'note\\d+_\\d+$':['al_wall.php',['wall.js','wall.css','wk.js','wk.css','pagination.js']],'notes(\\d+)?$':['al_wall.php',['wall.js','wall.css','wk.js','wk.css','pagination.js']],'bugs($|/)':['bugs.php',['bugs.css','bugs.js']],'wkview.php($)':['wkview.php',['wkview.js','wkview.css','wk.js','wk.css']],'stickers_office($|/)':['stickers_office.php',['stickers_office.css','stickers_office.js']],'charts($|/)':['al_audio.php',['audio.css','audio.js']],'maps($|/)':['maps.php',[]]}; var stVersions = { 'nav': 15148, 'common.js': 1099, 'common.css': 439, 'pads.js': 71, 'pads.css': 71, 'retina.css': 204, 'uncommon.js': 11, 'uncommon.css': 70, 'filebutton.css': 9, 'filebutton.js': 9, 'lite.js': 85, 'lite.css': 32, 'ie6.css': 26, 'ie7.css': 18, 'rtl.css': 154, 'pagination.js': 18, 'blog.css': 7, 'html5audio.js': 5, 'html5video.js': 32, 'html5video.css': 10, 'audioplayer.js': 138, 'audioplayer.css': 16, 'audio_html5.js': 7, 'audio.js': 235, 'audio.css': 126, 'gifts.css': 39, 'gifts.js': 40, 'indexer.js': 19, 'graph.js': 35, 'graph.css': 1, 'boxes.css': 22, 'box.js': 5, 'rate.css': 4, 'tooltips.js': 69, 'tooltips.css': 81, 'sorter.js': 21, 'qsorter.js': 25, 'usorter.js': 2, 'phototag.js': 7, 'phototag.css': 2, 'photoview.js': 346, 'photoview.css': 170, 'friendsphotos.js': 13, 'friendsphotos.css': 17, 'friends.js': 201, 'friends.css': 144, 'friends_search.js': 14, 'friends_search.css': 8, 'board.js': 70, 'board.css': 48, 'photos.css': 79, 'photos.js': 72, 'photos_add.css': 17, 'photos_add.js': 40, 'wkpoll.js': 13, 'wkview.js': 124, 'wkview.css': 111, 'single_pv.css': 9, 'single_pv.js': 4, 'video.js': 128, 'video.css': 114, 'videoview.js': 207, 'videoview.css': 125, 'video_edit.js': 17, 'video_edit.css': 17, 'translation.js': 13, 'translation.css': 5, 'reg.css': 26, 'reg.js': 56, 'invite.css': 11, 'invite.js': 10, 'prereg.js': 14, 'index.css': 26, 'index.js': 30, 'join.css': 62, 'join.js': 90, 'intro.css': 21, 'owner_photo.js': 23, 'owner_photo.css': 12, 'page.js': 815, 'page.css': 659, 'about.css': 1, 'page_fixed.css': 24, 'page_help.css': 16, 'public.css': 65, 'public.js': 43, 'events.css': 32, 'events.js': 38, 'pages.css': 48, 'pages.js': 40, 'groups.css': 101, 'groups.js': 34, 'groups_list.js': 56, 'groups_edit.css': 56, 'groups_edit.js': 75, 'profile.css': 210, 'profile.js': 208, 'calendar.css': 5, 'calendar.js': 13, 'wk.css': 38, 'wk.js': 14, 'pay.css': 3, 'pay.js': 6, 'tagger.js': 15, 'tagger.css': 13, 'qsearch.js': 11, 'wall.css': 72, 'wall.js': 72, 'walledit.js': 53, 'thumbs_edit.css': 6, 'thumbs_edit.js': 22, 'mail.css': 80, 'mail.js': 92, 'email.css': 2, 'im.css': 277, 'im.js': 275, 'emoji.js': 51, 'wide_dd.css': 12, 'wide_dd.js': 27, 'writebox.css': 9, 'writebox.js': 41, 'sharebox.js': 17, 'fansbox.js': 29, 'postbox.css': 4, 'postbox.js': 6, 'feed.js': 359, 'feed.css': 214, 'privacy.js': 92, 'privacy.css': 52, 'apps.css': 150, 'apps.js': 224, 'apps_edit.js': 85, 'apps_edit.css': 80, 'apps_check.js': 21, 'apps_check.css': 20, 'settings.js': 84, 'settings.css': 72, 'profile_edit.js': 82, 'profile_edit.css': 34, 'profile_edit_edu.js': 4, 'profile_edit_job.js': 5, 'profile_edit_mil.js': 2, 'search.js': 103, 'search.css': 78, 'datepicker.js': 25, 'datepicker.css': 10, 'oauth_popup.css': 28, 'oauth_page.css': 12, 'oauth_touch.css': 3, 'notes.css': 18, 'notes.js': 30, 'wysiwyg.js': 46, 'wysiwyg.css': 34, 'wiki.css': 10, 'fave.js': 48, 'fave.css': 49, 'widget_comments.css': 86, 'widget_community.css': 59, 'widget_post.css': 3, 'api/widgets/al_comments.js': 111, 'api/widgets/al_poll.js': 6, 'api/widgets/al_community.js': 55, 'api/widgets/al_like.js': 28, 'api/widgets/al_post.js': 7, 'al_poll.css': 3, 'widget_recommended.css': 3, 'widgets.css': 20, 'common_light.js': 1, 'developers.css': 6, 'touch.css': 7, 'notifier.js': 259, 'notifier.css': 82, 'restore.js': 20, 'restore.css': 11, 'recover.js': 1, 'recover.css': 3, 'docs.js': 60, 'docs.css': 67, 'tags_dd.js': 17, 'tags_dd.css': 16, 'tasks.js': 24, 'tasks.css': 31, 'tickets.js': 146, 'tickets.css': 120, 'faq.js': 14, 'faq.css': 17, 'bugs.js': 22, 'bugs.css': 22, 'login.css': 44, 'upload.js': 86, 'graffiti.js': 26, 'graffiti.css': 22, 'abuse.js': 15, 'abuse.css': 18, 'verify.css': 6, 'stats.css': 25, 'payments.css': 37, 'payments.js': 6, 'offers.css': 17, 'offers.js': 23, 'call.js': 75, 'call.css': 13, 'aes_light.css': 34, 'aes_light.js': 33, 'ads.css': 71, 'ads.js': 53, 'ads_payments.js': 4, 'ads_edit.css': 27, 'ads_edit.js': 99, 'ads_moder.css': 35, 'ads_moder.js': 38, 'ads_tagger.js': 2, 'ads_web.css': 11, 'ads_web.js': 26, 'health.css': 11, 'health.js': 5, 'pinbar.js': 6, 'sms_office.css': 17, 'sms_office.js': 12, 'help.css': 17, 'help.js': 11, 'claims.css': 6, 'claims.js': 4, 'site_stats.css': 8, 'site_stats.js': 5, 'meminfo.css': 11, 'blank.css': 3, 'wk_editor.js': 70, 'wk_editor.css': 28, 'btagger.js': 12, 'btagger.css': 11, 'filters.js': 56, 'dev.js': 53, 'dev.css': 63, 'share.css': 6, 'stickers_office.css': 1, 'stickers_office.js': 1, 'mapbox.js': 1, 'mapbox.css': 1, 'exchange.css': 22, 'exchange.js': 18, 'ads_offers.css': 9, 'ads_offers.js': 11, 'ads_offers_moder.css': 4, 'ads_offers_moder.js': 3, 'ui_controls.js': 153, 'ui_controls.css': 49, 'selects.js': 23, 'mentions.js': 50, 'apps_flash.js': 65, 'maps.js': 23, 'places.js': 38, 'places.css': 35, 'map2.js': 4, 'map.css': 6, 'sort.js': 8, 'paginated_table.js': 49, 'paginated_table.css': 8, 'q_frame.php': 7, '/swf/api_wrapper.swf': 7, '/swf/api_external.swf': 8, '/swf/api_wrapper2_0.swf': 8, '/swf/queue_transport.swf': 10, '/swf/audio_lite.swf': 13, '/swf/uploader_lite.swf': 12, '/swf/photo_uploader_lite.swf': 14, '/swf/CaptureImg.swf': 11, '/swf/video.swf': 28, '/swf/vkvideochat.swf': 49, '/swf/vchatdevices.swf': 1, 'favicon': 3, 'lang': 6548}; var stTypes = {fromLib:{'md5.js':1,'ui_controls.js':1,'selects.js':1,'sort.js':1,'maps.js':1},fromRoot:{'api/openapi.js':1,'api/share.js':1,'apps_flash.js':1,'mentions.js':1,'map2.js':1,'ui_controls.css':1,'map.css':1,'paginated_table.js':1,'paginated_table.css':1}}; var _rnd = 215;