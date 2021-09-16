<template>
  <div id="container">
    <a-form
      :model="formState.user"
      :layout="formState.layout"
      :rules="rules"
      ref="formRef"
    >
      <a-form-item label="注册" name="email">
        <a-input v-model:value="formState.user.email" placeholder="邮箱">
          <template #prefix>
            <MailOutlined />
          </template>
        </a-input>
      </a-form-item>
      <a-form-item name="name">
        <a-input v-model:value="formState.user.name" placeholder="用户名">
          <template #prefix>
            <UserAddOutlined />
          </template>
        </a-input>
      </a-form-item>
      <a-form-item name="password">
        <a-input-password
          placeholder="密码"
          v-model:value="formState.user.password"
        >
          <template #prefix>
            <LockOutlined />
          </template>
          <template #suffix>
            <EyeInvisibleOutlined />
          </template>
        </a-input-password>
      </a-form-item>
      <a-form-item name="confirmedPassword">
        <a-input-password
          placeholder="密码确认"
          v-model:value="formState.user.confirmedPassword"
        >
          <template #prefix>
            <LockOutlined />
          </template>
          <template #suffix>
            <EyeInvisibleOutlined />
          </template>
        </a-input-password>
      </a-form-item>
      <a-form-item>
        <a-button class="register" type="primary" @click="onSubmit()"
          >继续</a-button
        >
        <router-link class="haveaccount" :to="{ name: 'login' }"
          >已有账号</router-link
        >
      </a-form-item>
    </a-form>
  </div>
</template>
<script>
import { defineComponent, reactive, ref } from "vue";
import {
  LockOutlined,
  EyeInvisibleOutlined,
  MailOutlined,
  UserAddOutlined,
} from "@ant-design/icons-vue";
import { useRouter } from "vue-router";
import { isUserNameInvalid, emailVertify } from "../../api/login";
export default defineComponent({
  components: {
    LockOutlined,
    EyeInvisibleOutlined,
    MailOutlined,
    UserAddOutlined,
  },
  setup() {
    const formRef = ref();
    const formState = reactive({
      user: {
        vertifyCode: "",
        email: "763111123@qq.com",
        name: "weeeee",
        password: "123456",
        confirmedPassword: "123456",
      },
      layout: "vertical",
    });
    let validatePass2 = async (rule, value) => {
      if (value === "") {
        return Promise.reject("请输入密码");
      } else if (value !== formState.user.password) {
        return Promise.reject("两次输入的密码不一致");
      } else {
        return Promise.resolve();
      }
    };
    let validateName = async (rule, value) => {
      if (value === "") {
        return Promise.reject("请输入用户名");
      }
      if (value.length < 3 || value.length > 20) {
        return Promise.reject("用户名长度必须为3~10个字符");
      }
      let isValid = await isUserNameInvalid(value);
      if (isValid === false) {
        return Promise.reject("用户名已存在");
      }
      return Promise.resolve();
    };
    const rules = {
      name: [{ validator: validateName, trigger: "blur" }],
      email: [
        { required: true, message: "请输入邮箱", trigger: "blur" },
        {
          pattern:
            "^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$",
          message: "邮箱无效",
          trigger: "blur",
        },
      ],

      password: [
        { required: true, message: "请输入密码", trigger: "blur" },
        { min: 5, max: 20, message: "密码长度在5~20", trigger: "blur" },
      ],
      confirmedPassword: [{ validator: validatePass2, trigger: "change" }],
    };
    const router = useRouter();
    const onSubmit = () => {
      formRef.value
        .validate()
        .then(async () => {
          formState.user.vertifyCode = await emailVertify(formState.user.email);
          console.log(formState.user);
          router.push({ path: `vertifyEmail/${formState.user.email}`, params: {user:formState.user} });
        })
        .catch((error) => {
          console.log("error", error);
        });
    };

    return {
      formRef,
      formState,
      rules,
      validatePass2,
      onSubmit,
    };
  },
});
</script>

<style lang="less" scoped>
#container {
  width: 800px;
  margin: 20px auto;
  .ant-form {
    width: 400px;
    margin: 0 auto;
  }
  .vertifycode {
    width: 320px;
  }
  .vertify {
    float: right;
  }
  .register {
    width: 320px;
  }
  .haveaccount {
    float: right;
    padding-top: 5px;
  }
}
</style>