<template>
  <div id="container">
    <a-form
      id="loginform"
      :model="formState"
      :layout="formState.layout"
      :rules="rules"
    >
      <a-tabs
        v-model:activeKey="activeKey"
        :tabBarStyle="{ textAlign: 'center', borderBottom: 'unset' }"
      >
        <a-tab-pane key="1" tab="Tab 1">
          <a-form-item name="userName">
            <a-input placeholder="用户名" v-model:value="formState.userName">
              <template #prefix>
                <UserOutlined />
              </template>
              <template #suffix>
                <a-tooltip title="用户名">
                  <info-circle-outlined style="color: rgba(0, 0, 0, 0.45)" />
                </a-tooltip>
              </template>
            </a-input>
          </a-form-item>
          <br />
          <a-form-item name="password">
            <a-input-password
              placeholder="请输入密码"
              v-model:value="formState.password"
            >
            </a-input-password>
          </a-form-item>
        </a-tab-pane>
        <a-tab-pane key="2" tab="Tab 2" force-render>
          <a-form-item name="mobile">
            <a-input placeholder="电话号码" v-model:value="formState.mobile">
              <template #prefix>
                <MobileOutlined />
              </template>
            </a-input>
          </a-form-item>
          <br />
          <a-row>
            <a-col :span="16">
              <a-form-item name="vertifyCode">
                <a-input
                  v-model:value="formState.vertifyCode"
                  placeholder="请输入验证码"
                />
              </a-form-item>
            </a-col>
            <a-col :span="6" offset="2">
              <a-form-item>
                <a-button @click="doVertifyButtonClick()" type="primary"
                  >发送验证码</a-button
                >
              </a-form-item>
            </a-col>
          </a-row>
        </a-tab-pane>
      </a-tabs>
      <a-form-item>
        <a-checkbox v-model:checked="checked">记住密码</a-checkbox>
        <a href="" class="forget"> 忘记密码？</a>
      </a-form-item>
      <a-form-item>
        <a-button type="primary" block>登录</a-button>
      </a-form-item>
      <a-form-item>
        <a href="">Sign in with</a>
        <span class="otherlogin">
          <a href=""><WechatOutlined /></a>
          <a href=""><AlipayCircleOutlined /></a>
          <a href=""><QqOutlined /></a>
        </span>
        <router-link class="signup" :to="{ name: 'register' }"
          >Sign up</router-link
        >
      </a-form-item>
    </a-form>
  </div>
</template>
<script>
import { defineComponent, reactive, toRaw, ref } from "vue";
import { sendVertifyCode } from "../../api/login";
import {
  WechatOutlined,
  AlipayCircleOutlined,
  QqOutlined,
  UserOutlined,
  MobileOutlined,
} from "@ant-design/icons-vue";
export default defineComponent({
  components: {
    WechatOutlined,
    AlipayCircleOutlined,
    QqOutlined,
    UserOutlined,
    MobileOutlined,
  },
  setup() {
    const rules = {
      userName: [
        { required: true, message: "必须", trigger: "blur" },
        { min: 3, max: 5, message: "Length should be 3 to 5", trigger: "blur" },
      ],
      password: [{ required: true, message: "请输入密码", trigger: "change" }],
      mobile: [
        {
          required: true,
          pattern: /^1[34578]\d{9}$/,
          message: "请输入正确的电话",
          trigger: "change",
        },
      ],
      vertifyCode: [
        { required: true, message: "请输入验证码", trigger: "blur" },
      ],
    };
    const formState = reactive({
      userName: "",
      password: "",
      mobile: "",
      region: undefined,
      date1: undefined,
      delivery: false,
      type: [],
      resource: "",
      desc: "",
      layout: "vertical",
      vertifyCode: "",
    });
    const onSubmit = () => {
      console.log("submit!", toRaw(formState));
    };
    const doVertifyButtonClick = async () => {
      await sendVertifyCode(formState.mobile);
    };
    return {
      doVertifyButtonClick,
      rules,
      labelCol: {
        span: 4,
      },
      wrapperCol: {
        span: 14,
      },
      formState,
      onSubmit,
      checked: ref(false),
    };
  },
});
</script>

<style lang="less" scoped>
#container {
  width: 700px;
  margin: 0 auto;
  #loginform {
    .otherlogin {
      a {
        margin-left: 20px;
      }
    }
    .signup {
      position: absolute;
      right: 0;
    }
  }
  width: 400px;
  display: block;
  margin: 0 auto;
  .forget {
    position: absolute;
    right: 0;
  }
}
</style>