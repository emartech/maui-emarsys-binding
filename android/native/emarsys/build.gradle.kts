plugins {
    id("com.android.library")
}

android {
    namespace = "com.emarsys.maui"
    compileSdk = 34

    defaultConfig {
        minSdk = 24
    }

    buildTypes {
        release {
            isMinifyEnabled = false
            proguardFiles(
                getDefaultProguardFile("proguard-android-optimize.txt"),
                "proguard-rules.pro"
            )
        }
    }
    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_1_8
        targetCompatibility = JavaVersion.VERSION_1_8
    }
}

// Create configuration for copyDependencies
configurations {
    create("copyDependencies")
}

dependencies {
    implementation("com.emarsys:emarsys-sdk:3.7.11")
    implementation("com.emarsys:emarsys-firebase:3.7.11")
    // Add package dependency for binding library
    // Uncomment line below and replace {dependency.name.goes.here} with your dependency
    // implementation("{dependency.name.goes.here}")

    // Copy dependencies for binding library
    // Uncomment line below and replace {dependency.name.goes.here} with your dependency
     "copyDependencies"("com.emarsys:emarsys-sdk:3.7.11")
     "copyDependencies"("com.emarsys:emarsys-firebase:3.7.11")
}

// Copy dependencies for binding library
project.afterEvaluate {
    tasks.register<Copy>("copyDeps") {
        from(configurations["copyDependencies"])
        into("${buildDir}/outputs/deps")
    }
    tasks.named("preBuild") { finalizedBy("copyDeps") }
}
